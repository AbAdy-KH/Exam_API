using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Domain.Entities
{
    public class Options
    {
        [Key]
        public required string Id { get; set; }
        public required string Text { get; set; }
        public required bool IsCorrect { get; set; }

        [ForeignKey("Question")]
        public required string QuestionId { get; set; }
        public Question? Question { get; set; }
    }
}
