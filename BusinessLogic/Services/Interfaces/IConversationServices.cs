using BusinessLogic.DTOs;

namespace BusinessLogic.Services.Interfaces
{
    public interface IConversationServices
    {
        int AddConversation(CreateConversationDTO createConversationDTO);
        bool DeleteConversation(int id);
        IEnumerable<ConversationDTO> GetAllConversations(int? customerId = null, int? freelancerId = null);
        ConversationDTO? GetConversationById(int id);
    }
}