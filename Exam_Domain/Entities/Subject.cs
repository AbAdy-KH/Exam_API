using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Domain.Entities
{
    public class Subject
    {
        [Key]
        public required string Id { get; set; }
        public required string Name { get; set; }
    }
}
