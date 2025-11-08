using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Domain.Entities
{
    public class SelectedAnswer
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [ForeignKey(nameof(ExamResult))]
        public required string ExamResultId { get; set; }
        public ExamResult? ExamResult { get; set; }
        [ForeignKey(nameof(Option))]
        public required string OptionId { get; set; }
        public Option? Option { get; set; }
    }
}
