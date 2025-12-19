using Exam_Application.common.DTOs.Exam;
using Exam_Application.common.DTOs.SavedExam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Application.Services.Interfaces
{
    public interface ISavedExamService
    {
        void SaveExam(CreateSaveExamDto savedExamDto);
        void UnsaveExam(string examId);
        List<GetExamInfoDto> GetSavedExamsForUser(string userId, int pageNumber, string filter, string subjectFilter);
    }
}
