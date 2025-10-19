using Exam_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Application.Services.Interfaces
{
    public interface IQuestionService
    {
        IEnumerable<Question> GetAllQuestions(string examId);
    }
}
