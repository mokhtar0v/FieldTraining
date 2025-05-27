using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class CreateFreelancerDTO
    {
        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Code Is Required")]
        public int ID { get; set; }

        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int PhoneNum { get; set; }
        public string Skills { get; set; } = null!; // Non-nullable reference type, must be initialized
    }
}
