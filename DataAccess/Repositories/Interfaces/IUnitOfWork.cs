namespace DataAccess.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IConversationRepository ConversationRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IFreelancerRepository FreelancerRepository { get; }
        IJobRepository JobRepository { get; }
        IMessageRepository MessageRepository { get; }

        int SaveChanges();
    }
}