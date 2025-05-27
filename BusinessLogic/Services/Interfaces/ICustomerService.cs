using BusinessLogic.DTOs;

namespace BusinessLogic.Services.Interfaces
{
    internal interface ICustomerService
    {
        int AddCustomer(CreateCustomerDTO customerDTO);
        IEnumerable<CustomerDTO> GetAllCustomers();
        CustomerDTO? GetCustomerByID(int id);
        int UpdateCustomer(UpdateCustomerDTO updateCustomerDTO, int id);
        bool DeleteCustomer(int id);

    }
}