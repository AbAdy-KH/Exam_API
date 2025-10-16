using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Domain.Entities
{
    public class Question
    {
        [Key]
        public required string Id { get; set; }
        public required string Text { get; set; }

        [ForeignKey("Exam")]
        public required string ExamId { get; set; }
        public Exam? Exam { get; set; }

        public List<Options>? Options { get; set; }
    }
}
