using Exam_Application.common.DTOs.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Application.common.DTOs.Exam
{
    public class UpdateExamDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string SubjectId { get; set; }
        public string Notes { get; set; }

        public List<UpdateQuestionDto> Questions { get; set; }
    }
}
