using Exam_Application.common.DTOs.UserAndAuth;
using Exam_Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exam_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("{userId}")]
        public ActionResult<GetUserProfileDto> GetUserProfile(string userId)
        {
            var user = _userService.GetUserProfileInfo(userId);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("search")]
        public ActionResult<List<GetUser>> GetAllUsersWithUsername([FromQuery] string username)
        {
            var users = _userService.GetAllUsersWithUsername(username);
            return Ok(users);
        }
    }
}
