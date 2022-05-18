using BackEnd_Travelity.Domain;

namespace BackEnd_Travelity.Services.ChatService
{
    public interface IChatService
    {
        Task<ICollection<Chat>> GetAllChats();
        Task<Chat> GetChatById(int id);
        Task<bool> ChatExistsByID(int id);

        Task<bool> CreateChat(Chat chat);
        Task<bool> DeleteChat(Chat chat);
    }
}
