global using DataAccess.Models;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Data.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Configure the primary key
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID).UseIdentityColumn(10,2)
                .ValueGeneratedOnAdd();
            // Configure properties
            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(20)");
            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnType("varchar(50)");
            builder.Property(c => c.PhoneNum)
                .IsRequired()
                .HasColumnType("int");
            builder.Property(c => c.DateOfBirth)
                .IsRequired()
                .HasColumnType("datetime");
            // Configure soft delete
            builder.Property(c => c.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
