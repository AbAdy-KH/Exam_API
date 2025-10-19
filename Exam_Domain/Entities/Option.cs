using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Exam_Domain.Entities
{
    public class Option
    {
        [Key]
        public required string Id { get; set; } = Guid.NewGuid().ToString();
        public required string Text { get; set; }
        public required bool IsCorrect { get; set; }

        [ForeignKey("Question")]
        public required string QuestionId { get; set; }

        [JsonIgnore]
        public Question? Question { get; set; }
    }
}
