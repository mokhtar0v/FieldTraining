using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Configurations
{
    public class JobApplicationConfiguration : IEntityTypeConfiguration<JobApplication>
    {
        public void Configure(EntityTypeBuilder<JobApplication> builder)
        {
            builder.HasKey(a => a.ID);

            builder.HasOne(a => a.Job)
                   .WithMany(j => j.JobApplications)
                   .HasForeignKey(a => a.JobId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Freelancer)
                   .WithMany(f => f.JobApplications)
                   .HasForeignKey(a => a.FreelancerId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
