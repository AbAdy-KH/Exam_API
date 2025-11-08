using Exam_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Application.common.interfaces
{
    public interface ISelectedAnswerRepository : IRepository<SelectedAnswer>
    {
        void AddRange(IEnumerable<SelectedAnswer> selectedAnswers);
    }
}
