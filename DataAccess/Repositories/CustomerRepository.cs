using DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CustomerRepository(AppDbContext dbcontext) : ICustomerRepository
    {
        private readonly AppDbContext _dbcontext = dbcontext;

        public Customer? GetByID(int id)
        {
            var customer = _dbcontext.Customers.Find(id);
            return customer;
            //return _context.Customers.FirstOrDefault(c => c.ID == id && !c.IsDeleted);
        }

        public IEnumerable<Customer> GetAll(bool withTracking = false)
        {
            if (withTracking)
            {
                return _dbcontext.Customers.ToList();
            }
            else
            {
                return _dbcontext.Customers.AsNoTracking().ToList();
            }
        }

        public int Add(Customer customer)
        {
            _dbcontext.Customers.Add(customer);
            _dbcontext.SaveChanges();
            return customer.ID; // Assuming ID is auto-generated
        }
        public int Update(Customer customer)
        {
            _dbcontext.Customers.Update(customer);
            _dbcontext.SaveChanges();
            return customer.ID; // Assuming ID is auto-generated
        }
        public int Delete(int id)
        {
            var customer = _dbcontext.Customers.Find(id);
            if (customer != null)
            {
                _dbcontext.Customers.Remove(customer);
                _dbcontext.SaveChanges();
                return id; // Return the ID of the deleted customer
            }
            return 0; // Return 0 if no customer was found to delete
        }
    }
}
