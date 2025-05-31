using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class UpdateJobApplicationDTO
    {
        //public int Id 
        public string Status { get; set; } = null!; // Optional: only include if status updates are allowed
    }
}
