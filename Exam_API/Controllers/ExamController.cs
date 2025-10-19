using Exam_Application.common.DTOs;
using Exam_Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exam_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;
        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpPost("CreateExam")]
        public IActionResult Post([FromBody] CreateExamDto examDto)
        {
            if (examDto == null)
            {
                return BadRequest(new {message = "Exam is null"});
            }

            _examService.CreateExam(examDto);

            return Ok(new {message = "Exam created successfully"});
        }
    }
}
