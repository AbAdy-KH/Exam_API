using Exam_Application.common.interfaces;
using Exam_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Infrastructure.Repositories
{
    public class OptionRepository : Repository<Option>, IOptionRepository
    {
        private readonly ApplicationDbContext _db;
        public OptionRepository(ApplicationDbContext dp)
            : base(dp)
        {
            _db = dp;
        }
    }
}
