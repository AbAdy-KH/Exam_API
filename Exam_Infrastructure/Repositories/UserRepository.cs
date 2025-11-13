using Exam_Application.common.interfaces;
using Exam_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Infrastructure.Repositories
{
    public class UserRepository : Repository<ApplicationUser>, IUserReapository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) 
            : base(context)
        {
            _context = context;
        }
    }
}
