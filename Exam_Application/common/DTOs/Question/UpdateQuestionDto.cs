using Exam_Application.common.DTOs.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Application.common.DTOs.Question
{
    public class UpdateQuestionDto
    {
        public string? Id { get; set; }
        public string Text {  get; set; }
        
        public List<UpdateOptionDto> Options { get; set; }
    }
}
