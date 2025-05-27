using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    class CustomerDTO
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int PhoneNum { get; set; }
        public DateTime DateOfBirth { get; set; }
        // Additional properties can be added as needed
    }
}
