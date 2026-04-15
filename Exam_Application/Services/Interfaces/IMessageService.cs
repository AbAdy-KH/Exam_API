using Exam_Application.common.DTOs.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Application.Services.Interfaces
{
    public interface IMessageService
    {
        bool SaveMessage(string ReceiverId,  string Message);
        List<ChatDto> GetAllChats(string filter);
        List<MessageDto> GetChatMessages(string userId);
    }
}
