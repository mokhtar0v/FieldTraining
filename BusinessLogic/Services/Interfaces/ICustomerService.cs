using BusinessLogic.DTOs;

namespace BusinessLogic.Services.Interfaces
{
    public interface ICustomerService
    {
        int AddCustomer(CreateCustomerDTO customerDTO);
        IEnumerable<CustomerDTO> GetAllCustomers(string? CustomerSearchName);
        CustomerDTO? GetCustomerByID(int id);
        int UpdateCustomer(UpdateCustomerDTO updateCustomerDTO, int id);
        bool DeleteCustomer(int id);

    }
}