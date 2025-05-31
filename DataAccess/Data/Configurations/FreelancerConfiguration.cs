    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Configurations
{
    public class FreelancerConfiguration : IEntityTypeConfiguration<Freelancer>
    {
        public void Configure(EntityTypeBuilder<Freelancer> builder)
        {
            // Configure the primary key
            builder.HasKey(f => f.ID);
            builder.Property(f => f.ID).UseIdentityColumn(11, 2).
                ValueGeneratedOnAdd();
            // Configure properties
            builder.Property(f => f.Name)
                .IsRequired()
                .HasColumnType("varchar(50)");
            builder.Property(f => f.Email)
                .IsRequired()
                .HasColumnType("varchar(100)");
            builder.Property(f => f.PhoneNum)
                .IsRequired()
                .HasColumnType("int");
            builder.Property(f => f.DateOfBirth)
                .IsRequired()
                .HasColumnType("datetime");
            // Configure soft delete
            builder.Property(f => f.IsDeleted)
                .HasDefaultValue(false);

            //builder.Property(f => f.Skills)
            //    .HasColumnType("varchar(200)");
        }
    }
}
