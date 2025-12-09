using Exam_Application.common.DTOs.ExamResult;
using Exam_Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Microsoft.AspNetCore.Authorization.Authorize]
    public class ExamResultController : ControllerBase
    {
        private readonly IExamResultService _examResultService;
        public ExamResultController(IExamResultService service)
        {
            _examResultService = service;
        }

        [HttpPost("create")]
        public ActionResult CreateExamResult([FromBody] CreateExamResultAndSelectedAnswersDto Dto)
        {
            if (Dto == null) return BadRequest("Exam result cann't be null");

            _examResultService.CreateExamResult(Dto);

            return Ok();
        }

        [HttpGet("{examResultId}")]
        public ActionResult<GetExamResutlAndSelectedAnswersDto> GetExamResult(string examResultId)
        {
            var examResultDto = _examResultService.GetExamResult(examResultId);

            if (examResultDto == null) return NotFound("Exam result not found");

            return Ok(examResultDto);
        }

        [HttpGet]
        public ActionResult<List<GetExamResultDto>> GetAllExamResults([FromQuery] string userId)
        {
            if(string.IsNullOrEmpty(userId)) return BadRequest("User id cann't be null or empty");

            try
            {
                var examResultsDto = _examResultService.GetAllExamResults(userId);

                return Ok(examResultsDto);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
