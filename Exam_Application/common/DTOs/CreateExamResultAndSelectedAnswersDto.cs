using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Application.common.DTOs
{
    public class CreateExamResultAndSelectedAnswersDto
    {
        public CreateExamResultDto ExamResultDto { get; set; }
        public List<string> SelectedAnswersIds { get; set; }
    }
}
