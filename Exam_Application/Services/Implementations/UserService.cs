using Exam_Application.common.DTOs.UserAndAuth;
using Exam_Application.common.interfaces;
using Exam_Application.Services.Interfaces;
using Exam_Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        public string GetCurrentUserId()
        {
            return _httpContextAccessor.HttpContext?
                    .User?
                    .FindFirstValue(ClaimTypes.NameIdentifier);
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

        public List<GetUser> GetAllUsersWithUsername(string username = "", int pageNumber = 1)
        {
            string currentUserId = GetCurrentUserId();
            var response = _unitOfWork.User
                .GetAll(u => u.UserName.Contains(username) && u.Id != currentUserId)
                .Skip((pageNumber - 1) * 10)
                .Take(10)
                .Select(
                u => new GetUser
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    FullNmae = u.FullName
                }).ToList();

            return response;
        }
    }
}
