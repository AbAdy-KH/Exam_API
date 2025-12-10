using AutoMapper;
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
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public QuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<Question> GetAllQuestions(string examId)
        {
            IEnumerable<Question> questionList = _unitOfWork.Question
                .GetAll(q => q.ExamId == examId, "Options")
                .OrderBy(q => q.QuestionNumber);

            foreach (var item in questionList)
            {
                item.Options.OrderBy(o => o.OptionNumber);
            }

            return questionList;
        }
    }
}
