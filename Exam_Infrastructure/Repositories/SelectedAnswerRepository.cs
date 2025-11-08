using Exam_Application.common.interfaces;
using Exam_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Infrastructure.Repositories
{
    public class SelectedAnswerRepository : Repository<SelectedAnswer>, ISelectedAnswerRepository
    {
        private readonly ApplicationDbContext _db;
        public SelectedAnswerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void AddRange(IEnumerable<SelectedAnswer> selectedAnswers)
        {
            _db.SelectedAnswers.AddRange(selectedAnswers);
        }
    }
}
