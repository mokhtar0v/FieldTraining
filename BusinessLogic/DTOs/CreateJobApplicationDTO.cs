using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class CreateJobApplicationDTO
    {
        public int JobId { get; set; }
        public int FreelancerId { get; set; }
        public string? CoverLetter { get; set; }
        // Additional properties can be added here if needed
        // For example, you might want to include a resume or portfolio link
    }
}
