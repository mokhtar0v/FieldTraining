using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class UpdateJobDTO
    {
        public int Id { get; set; } // Assuming Id is the primary key for the job
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Budget { get; set; }
        public int? FreelancerId { get; set; }
        public JobStatus? Status { get; set; }
    }
}
