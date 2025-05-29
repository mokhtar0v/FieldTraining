using DataAccess.Repositories.Interfaces;
using AutoMapper;
using BusinessLogic.DTOs;
using DataAccess.Models;

namespace BusinessLogic.Services.Classes
{
    public class JobApplicationServices(IUnitOfWork _unitOfWork, IMapper _mapper)
    {
        public IEnumerable<JobApplicationDTO> GetAll()
        {
            var applications = _unitOfWork.JobRepository.GetAll();
            return _mapper.Map<IEnumerable<JobApplicationDTO>>(applications);
        }

        public JobApplicationDTO? GetById(int id)
        {
            var application = _unitOfWork.JobApplicationRepository.GetById(id);
            return application is null ? null : _mapper.Map<JobApplicationDTO>(application);
        }

        public int Create(CreateJobApplicationDTO dto)
        {
            var entity = _mapper.Map<JobApplication>(dto);
            _unitOfWork.JobApplicationRepository.Add(entity);
            _unitOfWork.SaveChanges();
            return entity.ID;
        }
        public int Update(int id, UpdateJobApplicationDTO dto)
        {
            var entity = _unitOfWork.JobApplicationRepository.GetById(id);
            if (entity == null) return 0;

            _mapper.Map(dto, entity);
            _unitOfWork.JobApplicationRepository.Update(entity);
            return _unitOfWork.SaveChanges();
        }

        public bool Delete(int id)
        {
            var entity = _unitOfWork.JobApplicationRepository.GetById(id);
            if (entity == null) return false;

            _unitOfWork.JobApplicationRepository.Remove(entity);
            return _unitOfWork.SaveChanges() > 0;
        }
    }
}
