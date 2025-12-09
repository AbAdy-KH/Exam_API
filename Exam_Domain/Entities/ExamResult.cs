using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Domain.Entities
{
    public class ExamResult
    {
        [Key]
        public required string Id { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey(nameof(Exam))]
        public required string ExamId { get; set; }
        public Exam? Exam { get; set; }

        public required double Mark {  get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public required string CreatedById { get; set; }
        public required ApplicationUser? CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}