using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class CreateCustomerDTO
    {
        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int PhoneNum { get; set; }
    }
}
