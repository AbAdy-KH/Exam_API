using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Application.common.DTOs.UserAndAuth
{
    public class GetUserProfileDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int ExamsTaken { get; set; }
        public int ExamsCreated { get; set; }
    }
}
