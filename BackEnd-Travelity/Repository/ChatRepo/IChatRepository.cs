using BackEnd_Travelity.Domain;

namespace BackEnd_Travelity.Repository.ChatRepo
{
    public interface IChatRepository
    {
        Task<ICollection<Chat>> GetAllChats();
        Task<Chat> GetChatById(int id);
        Task<bool> ChatExistsByID(int id);
        Task<bool> CreateChat(Chat chat);
        Task<bool> Save();
        Task<bool> DeleteChat(Chat chat);
    }
}
