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
        public IOptionRepository Option { get; private set; }
        public ISubjectRepository Subject { get; private set; }
        public IExamResultRepository ExamResult { get; private set; }
        public ISelectedAnswerRepository SelectedAnswer { get; private set; }
        public IUserReapository User { get; private set; }
        public ISavedExamRepository SavedExam { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Exam = new ExamRepository(_db);
            Question = new QuestionRepository(_db);
            Option = new OptionRepository(_db);
            Subject = new SubjectRepository(_db);
            ExamResult = new ExamResultRepository(_db);
            SelectedAnswer = new SelectedAnswerRepository(_db);
            User = new UserRepository(_db);
            SavedExam = new SavedExamRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
