using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Conversation : BaseEntity
    {
        // Foreign key to Customer
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        // Foreign key to Freelancer
        public int FreelancerId { get; set; }
        public virtual Freelancer Freelancer { get; set; }
        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
