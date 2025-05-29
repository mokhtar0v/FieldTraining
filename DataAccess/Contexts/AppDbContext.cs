using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using DataAccess.Data.Configurations;

namespace DataAccess.Contexts
{
    public class AppDbContext : DbContext
    {
        // Add this constructor to accept options
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Override OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new FreelancerConfiguration());
            modelBuilder.ApplyConfiguration(new JobConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new ConversationConfiguration());
            modelBuilder.ApplyConfiguration(new JobApplicationConfiguration());
        }

        // Your DbSets
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Freelancer> Freelancers { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }

    }
}
