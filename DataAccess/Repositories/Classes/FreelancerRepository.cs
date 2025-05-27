using DataAccess.Contexts;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Classes
{
    public class FreelancerRepository(AppDbContext dbcontext) : 
        GenericRepository<Freelancer>(dbcontext),
        IFreelancerRepository
    {
    }
}
