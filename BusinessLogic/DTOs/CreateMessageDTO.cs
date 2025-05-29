using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class CreateMessageDTO
    {
        public int ConversationId { get; set; }
        public bool IsFromCustomer { get; set; }
        public string Content { get; set; } = null!;
    }
}
