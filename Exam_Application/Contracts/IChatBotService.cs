using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Application.Contracts
{
    public interface IChatBotService
    {
        Task<string> GetResponse(string userInput);
    }
}
