using Exam_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Application.common.DTOs
{
    public class GetSelectedAnswerDto
    {
        public string QuestionText { get; set; }
        public string SelectedAnswerText { get; set; }
        public string CorrectAnswerText { get; set; }
    }
}
