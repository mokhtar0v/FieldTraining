using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Services.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;

namespace BusinessLogic.Services.Classes
{
    public class MessageService(IUnitOfWork _unitOfWork, IMapper _mapper) : IMessageService
    {
        public IEnumerable<MessageDTO> GetAllMessages(int conversationId)
        {
            var messages = _unitOfWork.MessageRepository.GetAll(m => m.ConversationId == conversationId);
            return _mapper.Map<IEnumerable<MessageDTO>>(messages);
        }

        public MessageDTO? GetMessageById(int id)
        {
            var message = _unitOfWork.MessageRepository.GetById(id);
            return message is null ? null : _mapper.Map<MessageDTO>(message);
        }

        public int AddMessage(CreateMessageDTO createMessageDTO)
        {
            var message = _mapper.Map<Message>(createMessageDTO);
            _unitOfWork.MessageRepository.Add(message);
            return _unitOfWork.SaveChanges();
        }

        public int UpdateMessage(int id, UpdateMessageDTO updateMessageDTO)
        {
            var message = _unitOfWork.MessageRepository.GetById(id);
            if (message == null) return 0;

            _mapper.Map(updateMessageDTO, message);
            _unitOfWork.MessageRepository.Update(message);
            return _unitOfWork.SaveChanges();
        }

        public bool DeleteMessage(int id)
        {
            var message = _unitOfWork.MessageRepository.GetById(id);
            if (message == null) return false;

            _unitOfWork.MessageRepository.Remove(message);
            return _unitOfWork.SaveChanges() > 0;
        }
    }
}
