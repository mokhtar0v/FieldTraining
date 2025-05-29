using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class MessageDTO
    {
        public int ID { get; set; }
        public int ConversationId { get; set; }
        public bool IsFromCustomer { get; set; }  // true if sent by customer, false if freelancer
        public string Content { get; set; } = null!;
    }
}
