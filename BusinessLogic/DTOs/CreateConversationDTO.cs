using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class CreateConversationDTO
    {
        public int CustomerId { get; set; }
        public int FreelancerId { get; set; }
        // Additional properties can be added here if needed
        // For example, a subject or initial message could be included
        // public string Subject { get; set; }
        // public string InitialMessage { get; set; }
    }
}
