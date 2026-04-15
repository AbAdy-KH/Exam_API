using Exam_Application.common.DTOs.UserAndAuth;
using Exam_Application.Common.DTOs.Friend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Application.Services.Interfaces
{
    public interface IFriendService
    {
        bool AddFriend(followRequestDto followRequest);
        bool RemoveFriend(string userId);
        List<GetUser> GetAllFriends();
    }
}
