using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public enum JobStatus
    {
        Open,       // Job posted and open for applications
        InProgress, // Job accepted and work is ongoing
        Completed,  // Job finished successfully
    }
    public class Job : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!; 
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; } = null!;
        public int? FreelancerID { get; set; }
        public virtual Freelancer? Freelancer { get; set; } = null!;
        public JobStatus Status { get; set; } = JobStatus.Open;
        public virtual ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
    }
}
