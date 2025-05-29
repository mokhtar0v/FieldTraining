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
    public class JobApplicationRepository(AppDbContext DbContext) : GenericRepository<JobApplication>(DbContext), IJobApplicationRepository
    {
        public IEnumerable<JobApplication> GetByFreelancerId(int freelancerId)
        {
            return DbContext.JobApplications
                .Where(j => j.FreelancerId == freelancerId)
                .ToList();
        }

        public IEnumerable<JobApplication> GetByJobId(int jobId)
        {
            return DbContext.JobApplications
                .Where(j => j.JobId == jobId)
                .ToList();
        }
    }
}
