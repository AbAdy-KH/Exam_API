using Exam_Application.common.DTOs;
using Exam_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Application.Services.Interfaces
{
    public interface IExamService
    {
        void CreateExam(CreateExamDto examDto);
        IEnumerable<GetExamInfoDto> GetAllExams(string filter);
        GetExamDetailsDto GetExamDetails(string examId);
        void UpdateFullExam(UpdateExamDto updateExamDto);
    }
}
