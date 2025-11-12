using AutoMapper;
using Exam_Application.common.DTOs;
using Exam_Application.common.interfaces;
using Exam_Application.Services.Interfaces;
using Exam_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Application.Services.Implementations
{
    public class ExamService : IExamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public ExamService(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userService = userService;
        }

        public void CreateExam(CreateExamDto examDto)
        {
            var exam = _mapper.Map<Exam>(examDto);
            exam.CreatedById = _userService.GetCurrentUserId();

            _unitOfWork.Exam.Add(exam);
            _unitOfWork.Save();
        }

        public IEnumerable<GetExamInfoDto> GetAllExams(string filter = "", string subjectFilter = "-1")
        {
            IEnumerable<Exam> examList = _unitOfWork.Exam.GetAll(e =>
                (e.Title.Contains(filter) || e.Subject.Name.Contains(filter)) &&
                (e.SubjectId == subjectFilter || subjectFilter == "-1"),
                "Subject, CreatedBy"
            );

            IEnumerable<GetExamInfoDto> examListDto = _mapper.Map<IEnumerable<GetExamInfoDto>>(examList);

            return examListDto;
        }

        public GetExamDetailsDto GetExamDetails(string examId)
        {
            Exam exam = _unitOfWork.Exam.Get(e => e.Id == examId, "Subject, CreatedBy");


            GetExamDetailsDto examDto = _mapper.Map<GetExamDetailsDto>(exam);

            return examDto;
        }

        public Exam GetFullExam(string examId)
        {
            var exam = _unitOfWork.Exam.Get(
                e => e.Id == examId,
                includeProperties: "Subject,Questions,Questions.Options"
            );
            return exam;
        }

        public void UpdateFullExam(UpdateExamDto updateExamDto)
        {
            var exam = _unitOfWork.Exam.Get(
                e => e.Id == updateExamDto.Id,
                includeProperties: "Questions,Questions.Options"
            );

            if (exam == null)
                throw new Exception("Exam not found");

            // === Update exam info ===
            exam.Title = updateExamDto.Title;
            exam.SubjectId = updateExamDto.SubjectId;
            exam.Notes = updateExamDto.Notes;

            // === Handle Questions ===
            var incomingQuestionIds = updateExamDto.Questions
                .Where(q => !string.IsNullOrEmpty(q.Id))
                .Select(q => q.Id)
                .ToList();

            // 🔹 Find questions that were removed
            var questionsToDelete = exam.Questions
                .Where(q => !incomingQuestionIds.Contains(q.Id))
                .ToList();

            foreach (var q in questionsToDelete)
            {
                _unitOfWork.Question.Delete(q);
            }

            // 🔹 Handle add/update
            foreach (var questionDto in updateExamDto.Questions)
            {
                if (string.IsNullOrEmpty(questionDto.Id))
                {
                    // Add new
                    var newQuestion = _mapper.Map<Question>(questionDto);
                    newQuestion.ExamId = exam.Id;

                    newQuestion.Id = Guid.NewGuid().ToString();
                    foreach (var item in newQuestion.Options.ToList())
                    {
                        item.Id = Guid.NewGuid().ToString();
                    }
                    _unitOfWork.Question.Add(newQuestion);
                }
                else
                {
                    // Update existing
                    var existingQuestion = exam.Questions.FirstOrDefault(q => q.Id == questionDto.Id);
                    if (existingQuestion == null) continue;

                    existingQuestion.Text = questionDto.Text;

                    // === Handle options ===
                    var incomingOptionIds = questionDto.Options
                        .Where(o => !string.IsNullOrEmpty(o.Id))
                        .Select(o => o.Id)
                        .ToList();

                    var optionsToDelete = existingQuestion.Options
                        .Where(o => !incomingOptionIds.Contains(o.Id))
                        .ToList();

                    foreach (var opt in optionsToDelete)
                        _unitOfWork.Option.Delete(opt);

                    foreach (var optionDto in questionDto.Options)
                    {
                        if (string.IsNullOrEmpty(optionDto.Id))
                        {
                            var newOption = _mapper.Map<Option>(optionDto);
                            optionDto.Id = Guid.NewGuid().ToString();

                            existingQuestion.Options.Add(newOption);
                        }
                        else
                        {
                            var existingOption = existingQuestion.Options.FirstOrDefault(o => o.Id == optionDto.Id);
                            if (existingOption == null) continue;

                            existingOption.Text = optionDto.Text;
                            existingOption.IsCorrect = optionDto.IsCorrect;
                        }
                    }
                }
            }

            _unitOfWork.Save();
        }
    }
}
