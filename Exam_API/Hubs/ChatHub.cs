using Exam_Application.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace Exam_API.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IMessageService _messageService;

        public ChatHub (IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task sendMessage(string receiverId, string message)
        {
            string senderId = Context.UserIdentifier;

            if(!(_messageService.SaveMessage(receiverId, message))) { return; }

            await Clients.User(receiverId).SendAsync("ReceiveMessage", message, senderId);
            await Clients.User(senderId).SendAsync("ReceiveMessage", message, senderId);
        }
    }
}
