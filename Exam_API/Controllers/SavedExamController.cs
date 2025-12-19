using Exam_Application.common.DTOs.SavedExam;
using Exam_Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class SavedExamController : ControllerBase
    {
        private readonly ISavedExamService _savedExamService;
        public SavedExamController(ISavedExamService savedExamService)
        {
            _savedExamService = savedExamService;

        }

        [HttpPost("save")]
        public IActionResult SaveExam([FromBody] CreateSaveExamDto saveExamDto)
        {
            _savedExamService.SaveExam(saveExamDto);
            return Ok();
        }

        [HttpDelete("delete{examId}")]
        public IActionResult UnsaveExam([FromQuery] string examId)
        {
            _savedExamService.UnsaveExam(examId);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetSavedExamsForUser([FromQuery] string userId, [FromQuery] int pageNumber = 1, [FromQuery] string filter = "", [FromQuery] string subjectFilter = "-1")
        {
            var savedExams = _savedExamService.GetSavedExamsForUser(userId, pageNumber, filter, subjectFilter);
            return Ok(savedExams);
        }
    }
}
