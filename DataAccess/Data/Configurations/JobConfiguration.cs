using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Configurations
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasKey(j => j.ID);

            builder.Property(j => j.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(j => j.Description)
                .HasMaxLength(3000);
            builder.HasOne(j => j.Customer)
                .WithMany(c => c.Jobs)
                .HasForeignKey(j => j.ID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(j => j.Freelancer)
                .WithMany(f => f.Jobs)
                .HasForeignKey(j => j.ID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
