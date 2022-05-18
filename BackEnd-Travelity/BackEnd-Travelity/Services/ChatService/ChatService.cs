using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Repository.ChatRepo;

namespace BackEnd_Travelity.Services.ChatService
{
    public class ChatService : IChatService
    {

        private readonly IChatRepository chatRepo;

        public ChatService(IChatRepository _chatRepo)
        {
            chatRepo = _chatRepo;
        }

        public async Task<ICollection<Chat>> GetAllChats() => await chatRepo.GetAllChats();
        public async Task<Chat> GetChatById(int id) => await chatRepo.GetChatById(id);
        public async Task<bool> ChatExistsByID(int id) => await chatRepo.ChatExistsByID(id);

        public async Task<bool> CreateChat(Chat chat) => await chatRepo.CreateChat(chat);
        public async Task<bool> DeleteChat(Chat chat) => await chatRepo.DeleteChat(chat);

    }
}
