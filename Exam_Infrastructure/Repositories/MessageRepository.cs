using Exam_Application.common.DTOs.Message;
using Exam_Application.common.interfaces;
using Exam_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Infrastructure.Repositories
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<Message> _messages;

        public MessageRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }

        public List<ChatDto> GetAllChats(string userId)
        {
            List<ChatDto> chats = _db.Messages
                .Include(m => m.Sender)
                .Include(m => m.Receiver)
                .GroupBy(m => (m.SenderId == userId) ? m.ReceiverId : m.SenderId)
                .Select(g => new ChatDto
                { 
                    UserId = g.Key,
                    UserName = g.Select(x => 
                        (x.SenderId == userId ? x.Receiver : x.Sender).UserName
                    )
                    .FirstOrDefault(),
                    LastMessage = g.Max(x => x.CreatedDate)
                })
                .ToList();

            return chats;
        }
    }
}
