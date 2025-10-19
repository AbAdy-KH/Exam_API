using Exam_Application.Services.Interfaces;
using Exam_Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exam_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet("{examId}")]
        public ActionResult<IEnumerable<Question>> GetAll([FromQuery]string examId)
        {
            IEnumerable<Question> questionList = _questionService.GetAllQuestions(examId);

            if(questionList == null || !questionList.Any())
            {
                return NotFound(new { message = "Exam not found" });
            }

            return Ok(questionList);
        }
    }
}
