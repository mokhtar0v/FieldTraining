using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class CustomerDTO
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!; // Non-nullable reference type, must be initialized
        public string Email { get; set; } = null!;
        public int PhoneNum { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
        // Additional properties can be added as needed
    }
}
