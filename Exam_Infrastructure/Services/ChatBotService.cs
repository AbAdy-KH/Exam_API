using Exam_Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenAI.Chat;
using OpenAI;

namespace Exam_Infrastructure.Services
{
    public class ChatBotService : IChatBotService
    {
        private readonly ChatClient _chatClient;

        public ChatBotService(ChatClient chatClient)
        {
            _chatClient = chatClient;
        }

        public async Task<string> GetResponse(string userInput)
        {
            ChatCompletion completion = await _chatClient.CompleteChatAsync(userInput);

            return completion.Content[0].Text;
        }
    }
}