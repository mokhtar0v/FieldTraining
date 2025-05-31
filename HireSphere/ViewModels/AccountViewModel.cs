using DataAccess.Models;
using System.ComponentModel.DataAnnotations;
namespace HireSphere.ViewModels
{
    public class AccountViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string FullName { get; set; } = null!;
        [Required]
        public int PhoneNumber { get; set; }
    }
}
