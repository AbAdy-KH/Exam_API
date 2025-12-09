using Exam_Application.common.DTOs.ExamResultAndSelectedAnswers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Application.Services.Interfaces
{
    public interface ISelectedAnswerService
    {
        void CreateSelectedAnswers(string examResultId, IEnumerable<string> answersId);
        IEnumerable<GetSelectedAnswerDto> GetSelectedAnswers(string examResultId);
    }
}
