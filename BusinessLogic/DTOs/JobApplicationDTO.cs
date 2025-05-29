using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class JobApplicationDTO
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public int FreelancerId { get; set; }
        public string? CoverLetter { get; set; }
        public ApplicationStatus Status { get; set; }
    }
}
