using Exam_Application.common.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IExamRepository Exam { get; private set; }
        public IQuestionRepository Question { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Exam = new ExamRepository(_db);
            Question = new QuestionRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
