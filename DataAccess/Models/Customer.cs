using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; } = null!; // Non-nullable reference type, must be initialized
        public string Email { get; set; } = null!;
        public int PhoneNum { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
