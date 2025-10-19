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
    public class Question
    {
        [Key]
        public required string Id { get; set; } = Guid.NewGuid().ToString();
        public required string Text { get; set; }

        [ForeignKey("Exam")]
        public required string ExamId { get; set; }
        [JsonIgnore]
        public Exam? Exam { get; set; }

        public List<Option>? Options { get; set; }
    }
}
