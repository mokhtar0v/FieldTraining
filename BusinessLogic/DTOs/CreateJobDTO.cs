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
    }
}
