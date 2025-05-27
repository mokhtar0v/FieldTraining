using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Message : BaseEntity
    {
        public string Content { get; set; } = string.Empty; // Non-nullable reference type, must be initialized
        public bool IsFromCustomer { get; set; }
        public int? ConversationId { get; set; }
        public virtual Conversation Conversation { get; set; }

    }
}
