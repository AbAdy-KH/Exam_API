using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Domain.Entities
{
    public class SavedExam
    {
        [Key]
        public required string Id { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey("AspNetUsers")]
        public required string UserId { get; set; }
        public ApplicationUser? User { get; set; }

        [ForeignKey("Exams")]
        public required string ExamId { get; set; }
        public Exam? Exam { get; set; }
    }
}
