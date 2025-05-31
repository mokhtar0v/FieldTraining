using BusinessLogic.DTOs;

namespace BusinessLogic.Services.Classes
{
    public interface IJobService
    {
        int AddJob(CreateJobDTO createJobDTO);
        bool DeleteJob(int id);
        IEnumerable<JobDTO> GetAllJobs();
        IEnumerable<JobDTO> GetAllJobs(string? JobSearchTitle);
        JobDTO? GetJobByID(int id);
        IEnumerable<JobDTO> GetJobsByCustomerId(int customerId);
        int UpdateJob(UpdateJobDTO updateJobDTO, int id);
    }
}