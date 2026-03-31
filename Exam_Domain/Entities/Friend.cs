using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Domain.Entities
{
    public class Friend
    {
        [Key]
        public required string Id { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string User1Id { get; set; }
        public ApplicationUser? User1 { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string User2Id { get; set; }
        public ApplicationUser User2 { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
