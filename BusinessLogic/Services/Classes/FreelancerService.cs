using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Services.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;

namespace BusinessLogic.Services.Classes
{
    public class FreelancerService(IUnitOfWork _unitOfWork, IMapper _mapper) : IFreelancerService
    {
        public IEnumerable<FreelancerDTO> GetAllFreelancers(string? FreelancerSearchName)
        {
            IEnumerable<Freelancer> freelancers;
            if (string.IsNullOrWhiteSpace(FreelancerSearchName))
                freelancers = _unitOfWork.FreelancerRepository.GetAll();
            else
                freelancers = _unitOfWork.FreelancerRepository.GetAll(e => e.Name.ToLower()
                                                    .Contains(FreelancerSearchName.ToLower()));
            var freelancersToReturn = _mapper.Map<IEnumerable<FreelancerDTO>>(freelancers);
            return freelancersToReturn;
        }
        public FreelancerDTO? GetFreelancerByID(int id)
        {
            var freelancer = _unitOfWork.FreelancerRepository.GetById(id);
            return freelancer is null ? null : _mapper.Map<FreelancerDTO>(freelancer);
        }
        public int AddFreelancer(CreateFreelancerDTO CreatefreelancerDTO)
        {
            var mappedFreelancer = _mapper.Map<Freelancer>(CreatefreelancerDTO);
            _unitOfWork.FreelancerRepository.Add(mappedFreelancer);
            return _unitOfWork.SaveChanges();

        }
        public int UpdateFreelancer(UpdateFreelancerDTO updateFreelancerDTO, int id)
        {
            var freelancer = _unitOfWork.FreelancerRepository.GetById(id);
            if (freelancer == null) return 0;
            _mapper.Map(updateFreelancerDTO, freelancer);
            _unitOfWork.FreelancerRepository.Update(freelancer);
            return _unitOfWork.SaveChanges();
        }
        public bool DeleteFreelancer(int id)
        {
            var freelancer = _unitOfWork.FreelancerRepository.GetById(id);
            if (freelancer is null)
            {
                return false; // Freelancer not found
            }
            else
            {
                _unitOfWork.FreelancerRepository.Remove(freelancer);
                return _unitOfWork.SaveChanges() > 0; // Return true if deletion was successful
            }
        }
    }
}
