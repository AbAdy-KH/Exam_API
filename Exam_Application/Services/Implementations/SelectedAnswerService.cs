using AutoMapper;
using Exam_Application.common.DTOs.ExamResultAndSelectedAnswers;
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
    public class SelectedAnswerService : ISelectedAnswerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SelectedAnswerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void CreateSelectedAnswers(string examResultId, IEnumerable<string> answersId)
        {
            _unitOfWork.SelectedAnswer.AddRange(
                answersId.Select(answerId => new SelectedAnswer
                {
                    ExamResultId = examResultId,
                    OptionId = answerId
                })
            );

            _unitOfWork.Save();
        }
    
        public IEnumerable<GetSelectedAnswerDto> GetSelectedAnswers(string examResultId)
        {
            var selectedAnswers = _unitOfWork.SelectedAnswer.
                GetAll(sa => sa.ExamResultId == examResultId, "Option");

            List<GetSelectedAnswerDto> selectedAnswersDto = new List<GetSelectedAnswerDto>();
            foreach (var item in selectedAnswers)
            {
                string questionId = item.Option.QuestionId;

                var question = _unitOfWork.Question.Get(q => q.Id == questionId, "Options");

                Option correctAnswer = question.Options.FirstOrDefault(o => o.IsCorrect);


                GetSelectedAnswerDto dto = new GetSelectedAnswerDto
                {
                    QuestionText = question.Text,
                    SelectedAnswerText = item.Option.Text,
                    CorrectAnswerText = correctAnswer.Text
                };

                selectedAnswersDto.Add(dto);
            }

            return selectedAnswersDto;
        }
    }
}
