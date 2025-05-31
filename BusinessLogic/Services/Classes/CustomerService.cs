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
    public class CustomerService(IUnitOfWork _unitOfWork, IMapper _mapper) : ICustomerService
    {
        public IEnumerable<CustomerDTO> GetAllCustomers(string? CustomerSearchName)
        {
            IEnumerable<Customer> customers;
            if (string.IsNullOrWhiteSpace(CustomerSearchName))
                customers = _unitOfWork.CustomerRepository.GetAll();
            else
                customers = _unitOfWork.CustomerRepository.GetAll(e => e.Name.ToLower()
                                                    .Contains(CustomerSearchName.ToLower()));
            var customersToreturn = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
            return customersToreturn;
        }
        public CustomerDTO? GetCustomerByID(int id)
        {
            var customer = _unitOfWork.CustomerRepository.GetById(id);
            return customer is null ? null : _mapper.Map<CustomerDTO>(customer);
        }
        public int AddCustomer(CreateCustomerDTO createCustomerDTO)
        {
            var mappedCustomer = _mapper.Map<Customer>(createCustomerDTO);
            _unitOfWork.CustomerRepository.Add(mappedCustomer);
            return _unitOfWork.SaveChanges();
        }
        public int UpdateCustomer(UpdateCustomerDTO updateCustomerDTO, int id)
        {
            var customer = _unitOfWork.CustomerRepository.GetById(id);
            if (customer == null) return 0;
            _mapper.Map(updateCustomerDTO, customer);
            _unitOfWork.CustomerRepository.Update(customer);
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
                customer.IsDeleted = true;
                _unitOfWork.CustomerRepository.Update(customer);
                return _unitOfWork.SaveChanges() > 0 ? true : false;
            }
        }
    }
}
