using Exam_Application.common.DTOs.UserAndAuth;
using Exam_Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<bool>> Register(RegisterDto registerDto)
        {
            if (registerDto == null) return BadRequest();

            var response = await _authService.Register(registerDto);

            if(!response.Success) return BadRequest(new { response.Errors });

            return Ok(new { response.Message }); 
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDto loginDto)
        {
            var response = await _authService.Login(loginDto);
            if (!response.Success) return BadRequest(new { response.Errors });
            return Ok(new { response.Data });
        }
    }
}
;