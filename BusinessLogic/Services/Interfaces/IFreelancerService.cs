using BusinessLogic.DTOs;

namespace BusinessLogic.Services.Interfaces
{
    public interface IFreelancerService
    {
        int AddFreelancer(CreateFreelancerDTO freelancerDTO);
        bool DeleteCustomer(int id);
        IEnumerable<FreelancerDTO> GetAllFreelancers();
        FreelancerDTO? GetFreelancerByID(int id);
        int UpdateFreelancer(UpdateFreelancerDTO updateFreelancerDTO, int id);
    }
}