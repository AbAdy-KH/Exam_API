using Exam_Application.common.interfaces;
using Exam_Application.Common.DTOs.Friend;
using Exam_Application.Services.Interfaces;
using Exam_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Application.Services.Implementations
{
    public class FriendService : IFriendService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FriendService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool IsUser1FollowingUser2(string user1Id, string user2Id)
        {
            return _unitOfWork.Friend.Get(f => f.User1Id == user1Id && f.User2Id == user2Id) != null;
        }

        public bool AddFriend(AddFriendDto addFriendDto)
        {
            try
            {
                if(addFriendDto.User1Id == addFriendDto.User2Id)
                {
                    return false;
                }

                if(IsUser1FollowingUser2(addFriendDto.User1Id, addFriendDto.User2Id))
                {
                    return false;
                }


                Friend friendEntity = new Friend
                {
                    Id = Guid.NewGuid().ToString(),
                    User1Id = addFriendDto.User1Id,
                    User2Id = addFriendDto.User2Id,
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
    }
}
