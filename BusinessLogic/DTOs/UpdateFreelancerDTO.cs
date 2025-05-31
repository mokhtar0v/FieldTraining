using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class UpdateFreelancerDTO
    {
        //public int Id { get; set; } // Assuming Id is the primary key for the freelancer
        public string Name { get; set; } = null!; // Non-nullable reference type, must be initialized
        public string Email { get; set; } = null!;
        public int PhoneNum { get; set; }
        //public string Skills { get; set; } = null!; // Non-nullable reference type, must be initialized
    }
}
