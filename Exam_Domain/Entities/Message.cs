using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Domain.Entities
{
    public class Message
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey(nameof(ApplicationUser))]
        public required string SenderId { get; set; }
        public ApplicationUser? Sender { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public required string ReceiverId { get; set; }
        public ApplicationUser? Receiver { get; set; }

        [Required]
        public required string Content { get; set; }

        [Required]
        public DateTime? CreatedDate { get; set; }
    }
}
