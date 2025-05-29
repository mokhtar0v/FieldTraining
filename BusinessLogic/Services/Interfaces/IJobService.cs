using BusinessLogic.DTOs;

namespace BusinessLogic.Services.Interfaces
{
    public interface IJobService
    {
        int AddJob(CreateJobDTO createJobDTO);
        bool DeleteJob(int id);
        IEnumerable<JobDTO> GetAllJobs(string? JobSearchTitle);
        JobDTO? GetJobByID(int id);
        int UpdateJob(UpdateJobDTO updateJobDTO, int id);
    }
}