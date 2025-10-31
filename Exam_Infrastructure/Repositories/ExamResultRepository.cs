using Exam_Application.common.interfaces;
using Exam_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Infrastructure.Repositories
{
    public class ExamResultRepository : Repository<ExamResult>, IExamResultRepository
    {
        private readonly ApplicationDbContext _db;
        public ExamResultRepository(ApplicationDbContext db)
            : base(db)
        {
            _db = db;
        }
    }
}
