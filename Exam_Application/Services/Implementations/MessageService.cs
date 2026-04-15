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

        public List<ChatDto> GetAllChats(string filter = "")
        {
            string userId = _httpContextAccessor
                .HttpContext
                .User
                .FindFirstValue(ClaimTypes.NameIdentifier)!;

            List<ChatDto> chats = _unitOfWork.Message.GetAll(m =>
                ((m.SenderId == userId && m.Receiver.UserName.Contains(filter))
                    || (m.ReceiverId == userId && m.Sender.UserName.Contains(filter))
                )
            , "Sender, Receiver")
            .GroupBy(m => m.SenderId == userId ? m.ReceiverId : m.SenderId)
            .Select(g => new ChatDto
            {
                UserId = g.Key,
                UserName = g.Select(m => (m.SenderId == userId ? m.Receiver : m.Sender).UserName).FirstOrDefault(),
                LastMessage = g.Max(m => m.CreatedDate)
            }).ToList();


            return chats;
        }

        public List<MessageDto> GetChatMessages(string userId)
        {
            string currentUserId = _httpContextAccessor
                .HttpContext
                .User
                .FindFirstValue(ClaimTypes.NameIdentifier)!;

            IEnumerable<Message> messages = _unitOfWork.Message
                .GetAll(m =>
                    (m.SenderId == currentUserId && m.ReceiverId == userId)
                    || (m.SenderId == userId && m.ReceiverId == currentUserId)
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
