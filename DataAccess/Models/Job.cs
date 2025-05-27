using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Job : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!; 
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; } = null!;
        public int? FreelancerID { get; set; }
        public virtual Freelancer? Freelancer { get; set; } = null!; 
    }
}
