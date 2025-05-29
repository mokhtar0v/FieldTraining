using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public enum ApplicationStatus
    {
        Pending,
        Accepted,
        Rejected
    }
    public class JobApplication : BaseEntity
    {
        public int JobId { get; set; }
        public virtual Job Job { get; set; }

        public int FreelancerId { get; set; }
        public virtual Freelancer Freelancer { get; set; }

        public string? CoverLetter { get; set; }
        public ApplicationStatus Status { get; set; } = ApplicationStatus.Pending;
    }
}
