using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Services.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;

namespace BusinessLogic.Services.Classes
{
    public class ConversationServices(IUnitOfWork _unitOfWork, IMapper _mapper) : IConversationServices
    {
        public IEnumerable<ConversationDTO> GetAllConversations(int? customerId = null, int? freelancerId = null)
        {
            IEnumerable<Conversation> conversations;

            if (customerId.HasValue && freelancerId.HasValue)
            {
                conversations = _unitOfWork.ConversationRepository.GetAll(c =>
                    c.CustomerId == customerId.Value && c.FreelancerId == freelancerId.Value);
            }
            else if (customerId.HasValue)
            {
                conversations = _unitOfWork.ConversationRepository.GetAll(c => c.CustomerId == customerId.Value);
            }
            else if (freelancerId.HasValue)
            {
                conversations = _unitOfWork.ConversationRepository.GetAll(c => c.FreelancerId == freelancerId.Value);
            }
            else
            {
                conversations = _unitOfWork.ConversationRepository.GetAll();
            }

            return _mapper.Map<IEnumerable<ConversationDTO>>(conversations);
        }

        public ConversationDTO? GetConversationById(int id)
        {
            var conversation = _unitOfWork.ConversationRepository.GetById(id);
            return conversation == null ? null : _mapper.Map<ConversationDTO>(conversation);
        }

        public int AddConversation(CreateConversationDTO createConversationDTO)
        {
            var conversation = _mapper.Map<Conversation>(createConversationDTO);
            _unitOfWork.ConversationRepository.Add(conversation);
            return _unitOfWork.SaveChanges();
        }
        public bool DeleteConversation(int id)
        {
            var conversation = _unitOfWork.ConversationRepository.GetById(id);
            if (conversation == null)
                return false;

            _unitOfWork.ConversationRepository.Remove(conversation);
            return _unitOfWork.SaveChanges() > 0;
        }
    }
}
