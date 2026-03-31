using Exam_Application.common.DTOs.Message;
using Exam_Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Exam_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("chats")]
        public ActionResult<List<ChatDto>> GetAllChats(string userId)
        {
            List<ChatDto> chats = _messageService.GetAllChatsForUser(userId);

            return Ok(chats);
        }

        [HttpGet("chatMessages")]
        public ActionResult<List<MessageDto>> GetChatMessages(string user1, string user2)
        {
            List<MessageDto> messages = _messageService.GetChatMessages(user1, user2);

            return Ok(messages);
        }
    }
}