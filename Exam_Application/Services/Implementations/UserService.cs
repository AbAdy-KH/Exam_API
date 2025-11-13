using Exam_Application.common.DTOs;
using Exam_Application.common.interfaces;
using Exam_Application.Services.Interfaces;
using Exam_Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
        }

        public string GetCurrentUser()
        {
            //return _httpContextAccessor.HttpContext.User?.FindFirst("sub")?.Value;
            return "1";
        }

        public GetUserProfileDto GetUserProfileInfo(string userId)
        {
            var user = _unitOfWork.User.Get(usr => usr.Id == userId);
            if (user == null)
            {
                return null;
            }
            var examsCreated = _unitOfWork.Exam.GetAll(e => e.CreatedById == userId).Count();
            var examsTaken = _unitOfWork.ExamResult.GetAll(er=> er.CreatedById == userId).Count();
            return new GetUserProfileDto
            {
                Id = user.Id,
                UserName = user.UserName,
                FullName = user.FullName,
                Email = user.Email,
                ExamsCreated = examsCreated,
                ExamsTaken = examsTaken
            };
        }
    }
}
