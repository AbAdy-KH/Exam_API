using Exam_Application.common.interfaces;
using Exam_Application.Common.DTOs.Friend;
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
    public class FriendService : IFriendService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FriendService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public bool IsUser1FollowingUser2(string user1Id, string user2Id)
        {
            return _unitOfWork.Friend.Get(f => f.User1Id == user1Id && f.User2Id == user2Id) != null;
        }

        public bool AddFriend(followRequestDto followRequest)
        {
            try
            {
                string User1Id = _httpContextAccessor
                    .HttpContext.User
                    .Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                string User2Id = followRequest.followedUserId;

                if (User1Id == User2Id)
                {
                    return false;
                }

                if(IsUser1FollowingUser2(User1Id, User2Id))
                {
                    return false;
                }


                Friend friendEntity = new Friend
                {
                    Id = Guid.NewGuid().ToString(),
                    User1Id = User1Id,
                    User2Id = User2Id,
                    CreatedAt = DateTime.UtcNow
                };

                //Message messageEntity = new Message
                //{
                //    Id = Guid.NewGuid().ToString(),
                //    SenderId = addFriendDto.User1Id,
                //    ReceiverId = addFriendDto.User2Id,
                //    Content = "Hi",
                //    CreatedDate = DateTime.UtcNow
                //};

                _unitOfWork.Friend.Add(friendEntity);
                //_unitOfWork.Message.Add(messageEntity);
                _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool RemoveFriend(string userId)
        {
            try
            {
                string currentUserId = _httpContextAccessor
                        .HttpContext.User
                        .Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                string User2Id = userId;

                Friend friendEntity = _unitOfWork.Friend
                    .Get(f => f.User1Id == currentUserId && f.User2Id == User2Id);

                _unitOfWork.Friend.Delete(friendEntity);
                _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
