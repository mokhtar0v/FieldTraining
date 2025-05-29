using BusinessLogic.DTOs;

namespace BusinessLogic.Services.Interfaces
{
    public interface IFreelancerService
    {
        int AddFreelancer(CreateFreelancerDTO freelancerDTO);
        bool DeleteFreelancer(int id);
        IEnumerable<FreelancerDTO> GetAllFreelancers(string? FreelancerSearchName);
        FreelancerDTO? GetFreelancerByID(int id);
        int UpdateFreelancer(UpdateFreelancerDTO updateFreelancerDTO, int id);
    }
}