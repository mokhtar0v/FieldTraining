using BusinessLogic.DTOs;
using DataAccess.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public IEnumerable<CustomerDTO> GetAllCustomers()
        {
            var customers = _customerRepository.GetAll();
            var customersToRetuen = customers.Select(c => new CustomerDTO
            {
                ID = c.ID ,
                Name = c.Name,
                Email = c.Email,
                PhoneNum = c.PhoneNum,
                DateOfBirth = c.DateOfBirth
            });
            return customersToRetuen;
        }

    }
}
