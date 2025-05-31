using DataAccess.Models;

namespace HireSphere.ViewModels
{
    public class JobViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }
        public JobStatus Status = JobStatus.Open; // Default to Open status
        // Additional properties for view purposes
    }
}
