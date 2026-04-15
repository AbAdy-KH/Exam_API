using Exam_Application.common.DTOs.UserAndAuth;
using Exam_Application.Common.DTOs.Friend;
using Exam_Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exam_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly IFriendService _friendService;

        public FriendController(IFriendService friendService)
        {
            _friendService = friendService;
        }

        [HttpGet("All")]
        public ActionResult<List<GetUser>> GetAllFriends()
        {
            var res = _friendService.GetAllFriends();
            return res != null ? Ok(res) : BadRequest(res);
        }

        [HttpPost("Follow")]
        public ActionResult<bool> Follow(followRequestDto followRequest)
        {
            bool res = _friendService.AddFriend(followRequest);

            return res ? Ok(res) : BadRequest(res);
        }

        [HttpDelete("Unfollow/{userId}")]
        public ActionResult<bool> Unfollow(string userId)
        {
            bool res = _friendService.RemoveFriend(userId);
            return res ? Ok(res) : BadRequest(res);
        }
    }
}
