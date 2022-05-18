using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Environment;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_Travelity.Repository.ChatRepo
{
    public class ChatRepository : IChatRepository
    {
        private readonly DatabaseContext context;
        public ChatRepository(DatabaseContext _context)
        {
            context = _context;
        }

        public async Task<bool> CreateChat(Chat chat)
        {
            await context.AddAsync(chat);
            return await Save();
        }

        public async Task<bool> DeleteChat(Chat chat)
        {
            context.Remove(chat);
            return await Save();
        }

        public async Task<ICollection<Chat>> GetAllChats()
        {
            return await context.Chat.ToListAsync();
        }

        public async Task<Chat> GetChatById(int id)
        {
            return await context.Chat.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
        public async Task<bool> ChatExistsByID(int id)
        {
            return await context.Chat.AnyAsync(u => u.Id == id);
        }
    }
}
