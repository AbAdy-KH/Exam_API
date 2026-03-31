using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Application.common.DTOs.Message
{
    public class ChatDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public IEnumerable<MessageDto> Messages { get; set; }
        public DateTime? LastMessage {  get; set; }
    }
}
