using DataAccess.Repositories.Interfaces;
using AutoMapper;
using BusinessLogic.DTOs;
using DataAccess.Models;
using BusinessLogic.Services.Interfaces;
namespace BusinessLogic.Services.Classes
{
    public class JobService(IUnitOfWork _unitOfWork, IMapper _mapper) : IJobService
    {
        public IEnumerable<JobDTO> GetAllJobs(string? JobSearchTitle)
        {
            IEnumerable<Job> jobs;
            if (string.IsNullOrWhiteSpace(JobSearchTitle))
                jobs = _unitOfWork.JobRepository.GetAll();
            else
                jobs = _unitOfWork.JobRepository.GetAll(e => e.Title.ToLower()
                                                    .Contains(JobSearchTitle.ToLower()));
            var jobsToReturn = _mapper.Map<IEnumerable<JobDTO>>(jobs);
            return jobsToReturn;
        }
        public JobDTO? GetJobByID(int id)
        {
            var job = _unitOfWork.JobRepository.GetById(id);
            return job is null ? null : _mapper.Map<JobDTO>(job);
        }
        public int AddJob(CreateJobDTO createJobDTO)
        {
            var mappedJobs = _mapper.Map<Job>(createJobDTO);
            _unitOfWork.JobRepository.Add(mappedJobs);
            return _unitOfWork.SaveChanges();

        }
        public int UpdateJob(UpdateJobDTO updateJobDTO, int id)
        {
            var mappedJobs = _mapper.Map<Job>(updateJobDTO);
            _unitOfWork.JobRepository.Update(mappedJobs);
            return _unitOfWork.SaveChanges();
        }
        public bool DeleteJob(int id)
        {
            var job = _unitOfWork.JobRepository.GetById(id);
            if (job is null)
            {
                return false; // Freelancer not found
            }
            else
            {
                _unitOfWork.JobRepository.Remove(job);
                return _unitOfWork.SaveChanges() > 0; // Return true if deletion was successful
            }
        }
    }
}
