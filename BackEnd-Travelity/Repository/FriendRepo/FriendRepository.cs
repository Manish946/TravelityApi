using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Environment;
using Microsoft.EntityFrameworkCore;


namespace BackEnd_Travelity.Repository.FriendRepo
{
    public class FriendRepository : IFriendRepository
    {
        private readonly DatabaseContext context;
        public FriendRepository(DatabaseContext _context)
        {
            context = _context;
        }
        public async Task<bool> CreateFriend(Friend friend)
        {
            friend.DateAdded = DateTime.Now;
            await context.AddAsync(friend);
            return await Save();
        }

        public async Task<bool> DeleteFriend(Friend friend)
        {
            context.Remove(friend);
            return await Save();
        }

        public async Task<ICollection<Friend>> GetAllFriends()
        {
            return await context.Friend.ToListAsync();
        }

        public async Task<Friend> GetByFriendName(string name)
        {
            return await context.Friend.Where(i => i.Friend_Username == name).FirstOrDefaultAsync();
        }

        public async Task<Friend> GetFriendById(int id)
        {
            return await context.Friend.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> UpdateFriend(Friend friend)
        {
            context.Update(friend);
            return await Save();
        }
        public async Task<bool> FriendExistsByName(string name)
        {
            return await context.Friend.AnyAsync(u => u.Friend_Username == name);
        }

        public async Task<bool> FriendExistsByID(int id)
        {
            return await context.Friend.AnyAsync(u => u.Id == id);
        }
    }
}
