using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Environment;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_Travelity.Repository.FriendRequestRepo
{
    public class FriendRequestRepository : IFriendRequestRepository
    {
        private readonly DatabaseContext context;
        public FriendRequestRepository(DatabaseContext _context)
        {
            context = _context;
        }
        public async Task<bool> CreateFriendRequest(FriendRequest FriendRequest)
        {
            await context.AddAsync(FriendRequest);
            return await Save();
        }

        public async Task<bool> DeleteFriendRequest(FriendRequest FriendRequest)
        {
            context.Remove(FriendRequest);
            return await Save();
        }

        public async Task<ICollection<FriendRequest>> GetAllFriendRequests()
        {
            return await context.FriendRequest.ToListAsync();
        }

        public async Task<ICollection<FriendRequest>> GetByFriendRequestSender(string name)
        {
            return await context.FriendRequest.Where(i => i.Sender == name).ToListAsync();
        }
        public async Task<ICollection<FriendRequest>> GetByFriendRequestReceiver(string name)
        {
            return await context.FriendRequest.Where(i => i.Receiver == name).ToListAsync();
        }
        public async Task<FriendRequest> GetFriendRequestById(int id)
        {
            return await context.FriendRequest.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> UpdateFriendRequest(FriendRequest FriendRequest)
        {
            context.Update(FriendRequest);
            return await Save();
        }
        public async Task<bool> FriendRequestExistsBySender(string name)
        {
            return await context.FriendRequest.AnyAsync(u => u.Sender == name);
        }
        public async Task<bool> FriendRequestExistsByReceiver(string name)
        {
            return await context.FriendRequest.AnyAsync(u => u.Receiver == name);
        }
        public async Task<bool> FriendRequestExistsByID(int id)
        {
            return await context.FriendRequest.AnyAsync(u => u.Id == id);
        }
    }
}
