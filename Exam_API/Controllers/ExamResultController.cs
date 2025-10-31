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
        public ExamResultController(IExamResultService service)
        {
            _examResultService = service;
        }

        [HttpPost("create")]
        public ActionResult CreateExamResult(CreateExamResultDto examResultDto)
        {
            if (examResultDto == null) return BadRequest("Exam result cann't be null");

            _examResultService.CreateExamResult(examResultDto);

            return Ok();
        }
    }
}
