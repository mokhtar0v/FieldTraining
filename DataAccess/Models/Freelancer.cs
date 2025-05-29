using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Freelancer : BaseEntity
    {
        public string Name { get; set; } = null!; // Non-nullable reference type, must be initialized
        public string Email { get; set; } = null!;
        public int PhoneNum { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Skills { get; set; } = null!; // Non-nullable reference type, must be initialized
        public virtual ICollection<Conversation> Conversations { get; set; } = new List<Conversation>();
        public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
        public virtual ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();


    }
}
