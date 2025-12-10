using Exam_Application.common.DTOs.ExamResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Application.Services.Interfaces
{
    public interface IExamResultService
    {
        void CreateExamResult(CreateExamResultAndSelectedAnswersDto examResultDto);
        GetExamResutlAndSelectedAnswersDto GetExamResult(string examResultId);
        List<GetExamResultDto> GetAllExamResults(string userId);
        int NumberOfAttemptsToExam(string examId);
    }
}
