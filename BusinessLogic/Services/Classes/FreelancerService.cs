using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Services.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Classes
{
    public class FreelancerService(IUnitOfWork _unitOfWork, IMapper _mapper) : IFreelancerService
    {
        public IEnumerable<FreelancerDTO> GetAllFreelancers()
        {
            var freelancers = _unitOfWork.FreelancerRepository.GetAll();
            var freelancersToReturn = freelancers.Select(f => new FreelancerDTO
            {
                ID = f.ID,
                Name = f.Name,
                Email = f.Email,
                PhoneNum = f.PhoneNum,
                DateOfBirth = f.DateOfBirth,
                Skills = f.Skills
            });
            return freelancersToReturn;
        }
        public FreelancerDTO? GetFreelancerByID(int id)
        {
            var freelancer = _unitOfWork.FreelancerRepository.GetById(id);
            return freelancer is null ? null : new FreelancerDTO
            {
                ID = freelancer.ID,
                Name = freelancer.Name,
                Email = freelancer.Email,
                PhoneNum = freelancer.PhoneNum,
                DateOfBirth = freelancer.DateOfBirth,
                Skills = freelancer.Skills
            };
        }
        public int AddFreelancer(CreateFreelancerDTO CreatefreelancerDTO)
        {
            var mappedFreelancer = _mapper.Map<Freelancer>(CreatefreelancerDTO);
            _unitOfWork.FreelancerRepository.Add(mappedFreelancer);
            return _unitOfWork.SaveChanges();

        }
        public int UpdateFreelancer(UpdateFreelancerDTO updateFreelancerDTO, int id)
        {
            var mappedFreelancer = _mapper.Map<Freelancer>(updateFreelancerDTO);
            _unitOfWork.FreelancerRepository.Update(mappedFreelancer);
            return _unitOfWork.SaveChanges();
        }
        public bool DeleteCustomer(int id)
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
