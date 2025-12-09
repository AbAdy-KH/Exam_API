using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Application.common.DTOs.ExamResult
{
    public class GetExamResultDto
    {
        public string ExamResultId { get; set; }
        public string ExamTitle { get; set; }
        public string SubjectName { get; set; }
        public double Mark { get; set; }
    }
}
