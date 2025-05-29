using BusinessLogic.DTOs;

namespace BusinessLogic.Services.Interfaces
{
    internal interface IMessageService
    {
        int AddMessage(CreateMessageDTO createMessageDTO);
        bool DeleteMessage(int id);
        IEnumerable<MessageDTO> GetAllMessages(int conversationId);
        MessageDTO? GetMessageById(int id);
        int UpdateMessage(int id, UpdateMessageDTO updateMessageDTO);
    }
}