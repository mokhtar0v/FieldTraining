using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Configurations
{
    public class ConversationConfiguration : IEntityTypeConfiguration<Conversation>
    {
        public void Configure(EntityTypeBuilder<Conversation> builder)
        {
            builder.HasKey(c => c.ID);

            builder.Property(c => c.CustomerId)
                .ValueGeneratedOnAdd();
            builder.HasOne(c => c.Customer)
                .WithMany(cu => cu.Conversations)
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Freelancer)
                .WithMany(f => f.Conversations)
                .HasForeignKey(c => c.FreelancerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Messages)
                .WithOne(m => m.Conversation)
                .HasForeignKey(m => m.ConversationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
