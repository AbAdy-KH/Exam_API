using AutoMapper;
using Exam_Application.common.DTOs.ExamResult;
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
    public class ExamResultService : IExamResultService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISelectedAnswerService _selectedAnswerService;
        private readonly IUserService _userService;

        public ExamResultService(IUnitOfWork unitOfWork, IMapper mapper, ISelectedAnswerService selectedAnswerService, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _selectedAnswerService = selectedAnswerService;
            _userService = userService;
        }

        public void CreateExamResult(CreateExamResultAndSelectedAnswersDto Dto)
        {
            var examResult = _mapper.Map<ExamResult>(Dto.ExamResultDto);
            examResult.CreatedById = _userService.GetCurrentUserId();
            _unitOfWork.ExamResult.Add(examResult);

            examResult.CreatedAt = DateTime.UtcNow;
            _selectedAnswerService.CreateSelectedAnswers(examResult.Id, Dto.SelectedAnswersIds);
            _unitOfWork.Save();
        }

        public GetExamResutlAndSelectedAnswersDto GetExamResult(string examResultId)
        {
            var examResult = _unitOfWork.ExamResult.Get(er => er.Id == examResultId);

            var selectedAnswersDto = _selectedAnswerService.GetSelectedAnswers(examResultId);

            var examResultDto = new GetExamResutlAndSelectedAnswersDto
            {
                Mark = examResult.Mark,
                SelectedAnswers = selectedAnswersDto
            };

            return examResultDto;
        }

        public List<GetExamResultDto> GetAllExamResults(string userId)
        {
            IEnumerable<ExamResult> examResults;

            if(userId != _userService.GetCurrentUserId())
                throw new UnauthorizedAccessException("You are not authorized to view these exam results.");

            examResults = _unitOfWork.ExamResult
                .GetAll(e => e.CreatedById == userId, "Exam.Subject")
                .OrderByDescending(e => e.CreatedAt)
                .Take(20);

            List<GetExamResultDto> examResultsDto = new List<GetExamResultDto>();

            foreach (var item in examResults)
            {
                var examResultDto = new GetExamResultDto
                {
                    ExamResultId = item.Id,
                    ExamTitle = item.Exam.Title,
                    SubjectName = item.Exam.Subject.Name,
                    Mark = item.Mark
                };

                examResultsDto.Add(examResultDto);
            }

            return examResultsDto;
        }

        public int NumberOfAttemptsToExam(string examId)
        {
            return _unitOfWork.ExamResult.NumberOfAttemptsToExam(examId);
        }
    }
}
