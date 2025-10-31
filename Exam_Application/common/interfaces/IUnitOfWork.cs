using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Application.common.interfaces
{
    public interface IUnitOfWork
    {
        IExamRepository Exam { get; }
        IQuestionRepository Question { get; }
        IOptionRepository Option { get; }
        ISubjectRepository Subject { get; }
        IExamResultRepository ExamResult { get; }

        void Save();
    }
}
