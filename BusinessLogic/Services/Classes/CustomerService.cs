using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Services.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Classes
{
    class CustomerService(IUnitOfWork _unitOfWork, IMapper _mapper) : ICustomerService
    {
        public IEnumerable<CustomerDTO> GetAllCustomers()
        {
            var customers = _unitOfWork.CustomerRepository.GetAll();
            var customersToreturn = customers.Select(f => new CustomerDTO
            {
                ID = f.ID,
                Name = f.Name,
                Email = f.Email,
                PhoneNum = f.PhoneNum,
                DateOfBirth = f.DateOfBirth
            });
            return customersToreturn;
        }
        public CustomerDTO? GetCustomerByID(int id)
        {
            var customer = _unitOfWork.CustomerRepository.GetById(id);
            return customer is null ? null : new CustomerDTO
            {
                ID = customer.ID,
                Name = customer.Name,
                Email = customer.Email,
                PhoneNum = customer.PhoneNum,
                DateOfBirth = customer.DateOfBirth
            };
        }
        public int AddCustomer(CreateCustomerDTO customerDTO)
        {
            var mappedCustomer = _mapper.Map<Customer>(customerDTO);
            _unitOfWork.CustomerRepository.Add(mappedCustomer);
            return _unitOfWork.SaveChanges();
        }
        public int UpdateCustomer(UpdateCustomerDTO updateCustomerDTO, int id)
        {
            var mappedCustomer = _mapper.Map<Customer>(updateCustomerDTO);
            _unitOfWork.CustomerRepository.Update(mappedCustomer);
            return _unitOfWork.SaveChanges();
        }
        public bool DeleteCustomer(int id)
        {
            var customer = _unitOfWork.CustomerRepository.GetById(id);
            if (customer is null)
            {
                return false; // Freelancer not found
            }
            else
            {
                _unitOfWork.CustomerRepository.Remove(customer);
                return _unitOfWork.SaveChanges() > 0; // Return true if deletion was successful
            }
        }
    }
}
