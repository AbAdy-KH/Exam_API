﻿using Exam_Application.common.DTOs;
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
        public ActionResult<IEnumerable<GetExamInfoDto>> GetAll([FromQuery]string filter = "", [FromQuery] string subjectFilter = "-1")
        {
            var examList = _examService.GetAllExams(filter, subjectFilter);

            return Ok(examList);
        }

        [HttpGet("{examId}")]
        public ActionResult<GetExamDetailsDto> GetExam([FromQuery]string examId)
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

    }
}
