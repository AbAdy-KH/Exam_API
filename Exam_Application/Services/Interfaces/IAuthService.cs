using Exam_Application.common;
using Exam_Application.common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<Response<string>> Login(LoginDto loginDto);
        Task<Response<bool>> Register(RegisterDto register);
    }
}
