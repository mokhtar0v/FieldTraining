using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class JobDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Budget { get; set; }
        public DateTime Deadline { get; set; }
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; } // Optional property for customer name
        public JobStatus Status { get; set; }
    }
}
