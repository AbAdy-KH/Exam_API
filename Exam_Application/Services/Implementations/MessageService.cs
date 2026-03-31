using Exam_Application.common.interfaces;
using Exam_Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Exam_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Exam_Application.common.DTOs.Message;

namespace Exam_Application.Services.Implementations
{
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MessageService (IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;   
            _httpContextAccessor = httpContextAccessor;
        }

        public bool SaveMessage(string ReceiverId, string Message)
        {
            try
            {
                string senderId = _httpContextAccessor
                    .HttpContext
                    .User
                    .FindFirstValue(ClaimTypes.NameIdentifier)!;

                Message message = new Message()
                {
                    SenderId = senderId,
                    ReceiverId = ReceiverId,
                    Content = Message,
                    CreatedDate = DateTime.Now
                };

                _unitOfWork.Message.Add(message);
                _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<ChatDto> GetAllChatsForUser(string userId)
        {
            List<ChatDto> chats = _unitOfWork.Message.GetAllChats(userId);

            return chats;
        }

        public List<MessageDto> GetChatMessages(string user1, string user2)
        {
            IEnumerable<Message> messages = _unitOfWork.Message
                .GetAll(m =>
                    (m.SenderId == user1 && m.ReceiverId == user2)
                    || (m.SenderId == user2 && m.ReceiverId == user1)
                ).OrderBy(m => m.CreatedDate);

            List<MessageDto> messagesDto = 
                messages.Select(m => new MessageDto 
                { 
                    Id = m.Id, 
                    Content = m.Content, 
                    SenderId = m.SenderId, 
                    ReceiverId = m.ReceiverId,
                    SentAt = m.CreatedDate
                }).ToList();

            return messagesDto;
        }
    }
}
