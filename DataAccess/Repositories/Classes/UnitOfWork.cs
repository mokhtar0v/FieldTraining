using DataAccess.Contexts;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Lazy<ICustomerRepository> _customerRepository;
        private readonly Lazy<IFreelancerRepository> _freelancerRepository;
        private readonly Lazy<IConversationRepository> _conversationRepository;
        private readonly Lazy<IMessageRepository> _messageRepository;
        private readonly Lazy<IJobRepository> _jobRepository;

        private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _customerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(_appDbContext));
            _freelancerRepository = new Lazy<IFreelancerRepository>(() => new FreelancerRepository(_appDbContext));
            _conversationRepository = new Lazy<IConversationRepository>(() => new ConversationRepository(_appDbContext));
            _messageRepository = new Lazy<IMessageRepository>(() => new MessageRepository(_appDbContext));
            _jobRepository = new Lazy<IJobRepository>(() => new JobRepository(_appDbContext));
        }

        public ICustomerRepository CustomerRepository => _customerRepository.Value;

        public IFreelancerRepository FreelancerRepository => _freelancerRepository.Value;
        public IConversationRepository ConversationRepository => _conversationRepository.Value;
        public IMessageRepository MessageRepository => _messageRepository.Value;
        public IJobRepository JobRepository => _jobRepository.Value;

        public int SaveChanges()
        {
            return _appDbContext.SaveChanges();
        }
    }
}
