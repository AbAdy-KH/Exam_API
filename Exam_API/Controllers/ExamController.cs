using Exam_Application.common.DTOs.Exam;
using Exam_Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exam_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;
        public ExamController(IExamService examService, IHttpContextAccessor httpContextAccessor)
        {
            _examService = examService;
        }

        [HttpPost("CreateExam")]
        public ActionResult Post([FromBody] CreateExamDto examDto)
        {
            if (examDto == null)
            {
                return BadRequest(new {message = "Exam is null"});
            }

            _examService.CreateExam(examDto);

            return Ok(new {message = "Exam created successfully"});
        }

        [HttpGet]
        public ActionResult<IEnumerable<GetExamInfoDto>> GetAll([FromQuery]int pageNumber = 1, [FromQuery] string userId = "", [FromQuery]string filter = "", [FromQuery] string subjectFilter = "-1")
        {
            var examList = _examService.GetAllExams(pageNumber, userId, filter, subjectFilter);

            return Ok(examList);
        }

        [HttpGet("{examId}")]
        public ActionResult<GetExamDetailsDto> GetExamDetails([FromQuery]string examId)
        {
            var exam = _examService.GetExamDetails(examId);
            if (exam == null)
            {
                return NotFound(new { message = "Exam not found" });
            }
            return Ok(exam);
        }

        [HttpPut("update")]
        public IActionResult UpdateFullExam([FromBody] UpdateExamDto updateExamDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                Console.WriteLine("Model binding failed: " + string.Join(", ", errors));
                return BadRequest(errors);
            }

            try
            {
                _examService.UpdateFullExam(updateExamDto);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("full/{examId}")]
        public ActionResult<GetExamDetailsDto> GetFullExam([FromQuery] string examId)
        {
            var exam = _examService.GetFullExam(examId);
            if (exam == null)
            {
                return NotFound(new { message = "Exam not found" });
            }

            return Ok(exam);
        }
    }
}
