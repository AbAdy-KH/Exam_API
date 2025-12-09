using Exam_Application.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exam_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatBotController : ControllerBase
    {
        private readonly IChatBotService _chatBotService;

        public ChatBotController(IChatBotService chatBotService)
        {
            _chatBotService = chatBotService;
        }

        // POST api/<ChatBotController>
        [HttpPost("GetResponse")]
        public async Task<ActionResult<string>> GetResponse(string userPrompt)
        {
            var response = await _chatBotService.GetResponse(userPrompt);

            return Ok(response);
        }

    }
}
