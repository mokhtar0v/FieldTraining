using DataAccess.Contexts;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Classes
{
    public class ConversationRepository (AppDbContext dbContext):
        GenericRepository<Conversation>(dbContext),
        IConversationRepository
    {
        public IEnumerable<Conversation> GetConversationsByCustomerId(int customerId)
        {
            return dbContext.Conversations
                .Where(c => c.ID == customerId)
                .ToList();
        }
    }
}
