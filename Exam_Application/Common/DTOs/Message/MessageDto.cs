using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Application.common.DTOs.Message
{
    public class MessageDto
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string ReceiverId { get; set; }
        public string SenderId { get; set; }
        public DateTime? SentAt { get; set; }
    }
}
