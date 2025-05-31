using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class CreateJobDTO
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Budget { get; set; }
        public int CustomerId { get; set; }
        public int FreelancerId { get; set; } = 0; // Default to 0 if not assigned
        public JobStatus Status { get; set; } = JobStatus.Open; // Default to Open status
    }
}
