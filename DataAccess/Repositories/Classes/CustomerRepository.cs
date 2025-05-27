using DataAccess.Contexts;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Classes
{
    public class CustomerRepository(AppDbContext dbcontext) : 
        GenericRepository<Customer>(dbcontext),
        ICustomerRepository
    {

    }
}
