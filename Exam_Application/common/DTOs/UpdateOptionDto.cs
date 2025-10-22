using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Application.common.DTOs
{
    public class UpdateOptionDto
    {
        public string Id { get; set; }
        public string Text {  get; set; }
        public bool IsCorrect { get; set; }
    }
}
