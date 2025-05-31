using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class ConversationDTO
    {
        public int ID { get; set; }
        public int CustomerId { get; set; }
        public int FreelancerId { get; set; }
        public List<MessageDTO> Messages { get; set; } = new();
    }
}
