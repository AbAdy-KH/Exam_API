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

        [HttpPost]
        public ActionResult<bool> Follow(AddFriendDto addFriendDto)
        {
            bool res = _friendService.AddFriend(addFriendDto);

            return res ? Ok(res) : BadRequest(res);
        }
    }
}
