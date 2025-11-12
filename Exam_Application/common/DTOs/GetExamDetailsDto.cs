using Exam_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Application.common.DTOs
{
    public class GetExamDetailsDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public Subject Subject { get; set; }
        public string Notes { get; set; }
        public ApplicationUser CreatedBy { get; set; }
    }
}
