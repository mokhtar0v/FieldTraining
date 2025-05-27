using DataAccess.Contexts;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Classes
{
    public class MessageRepository(AppDbContext dbcontext) : GenericRepository<Message>(dbcontext), IMessageRepository
    {
        // You can add specific methods for MessageRepository here if needed
        // For example, you might want to add methods to get messages by conversation ID
        public async Task<List<Message>> GetMessagesByConversationIdAsync(int conversationId)
        {
            return await dbcontext.Messages
                .Where(m => m.ConversationId == conversationId)
                .ToListAsync();
        }
    }
}
