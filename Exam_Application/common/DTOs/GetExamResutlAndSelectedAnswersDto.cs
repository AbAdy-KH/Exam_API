using Exam_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Application.common.DTOs
{
    public class GetExamResutlAndSelectedAnswersDto
    {
        public double Mark { get; set; }
        public IEnumerable<GetSelectedAnswerDto> SelectedAnswers { get; set; }
    }
}
