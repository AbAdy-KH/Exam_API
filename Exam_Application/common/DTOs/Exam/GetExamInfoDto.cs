using Exam_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Application.common.DTOs.Exam
{
    public class GetExamInfoDto
    {
        public string Id { get; set; }

        //public string SubjectId { get; set; }
        public Subject Subject { get; set; }

        public string Title { get; set; }

        //public ApplicationUser CreatedBy { get; set; }
        public string Username { get; set; }
    }
}
