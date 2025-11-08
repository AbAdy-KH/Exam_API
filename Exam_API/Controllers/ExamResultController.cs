using Exam_Application.common.DTOs;
using Exam_Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamResultController : ControllerBase
    {
        private readonly IExamResultService _examResultService;
        //private readonly ISelectedAnswerService _selectedAnswerService;
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

        [HttpGet("all")]
        public ActionResult<List<GetExamResultDto>> GetAllExamResults()
        {
            var examResultsDto = _examResultService.GetAllExamResults();
            return Ok(examResultsDto);
        }
    }
}
