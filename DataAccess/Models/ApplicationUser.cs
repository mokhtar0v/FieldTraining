using Microsoft.AspNetCore.Identity;

namespace DataAccess.Models
{
    public class ApplicationUser : IdentityUser
    {
        public override string UserName
        {
            get => Id;
            set { /* Ignore setting username */ }
        }
        public string? FullName { get; set; } // Full name of the user, can be used for display purposes
        public string? UserType { get; set; } // "Customer" or "Freelancer"

    }
}
