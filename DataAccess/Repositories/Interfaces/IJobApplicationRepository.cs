namespace DataAccess.Repositories.Interfaces
{
    public interface IJobApplicationRepository : IGenericRepository<JobApplication>
    {
        IEnumerable<JobApplication> GetByFreelancerId(int freelancerId);
        IEnumerable<JobApplication> GetByJobId(int jobId);
    }
}