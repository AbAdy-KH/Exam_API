using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Domain.Entities
{
    public class Exam
    {
        [Key]
        public required string Id { get; set; } = Guid.NewGuid().ToString();
        public required string Title { get; set; }

        [ForeignKey("Subject")]
        public required string SubjectId { get; set; }
        public Subject? Subject { get; set; }

        public string? Notes { get; set; }

        public List<Question>? Questions { get; set; }

        [ForeignKey("ApplicationUser")]
        public required string CreatedById { get; set; }
        public ApplicationUser? CreatedBy { get; set; }
    }
}
