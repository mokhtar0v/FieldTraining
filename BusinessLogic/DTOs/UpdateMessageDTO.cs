using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
   public class UpdateMessageDTO
    {
        //public int Id { get; set; } // Assuming Id is the primary key for the message
        public string Content { get; set; } = null!; // Non-nullable reference type, must be initialized
    }
}
