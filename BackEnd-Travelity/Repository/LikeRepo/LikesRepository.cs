using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Environment;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_Travelity.Repository.LikeRepo
{
    public class LikeRepo : ILikeRepo
    {
        private readonly DatabaseContext context;
        public LikeRepo(DatabaseContext _context)
        {
            context = _context;
        }
        public async Task<bool> CreateLikes(Likes like)
        {
            await context.AddAsync(like);
            return await Save();
        }

        public async Task<bool> DeleteLikes(Likes like)
        {
            context.Remove(like);
            return await Save();
        }

        public async Task<ICollection<Likes>> GetAllLikes()
        {
            return await context.Likes.ToListAsync();
        }

        public async Task<Likes> GetByLikesFollow(string follow)
        {
            return await context.Likes.Where(n => n.Follow == follow).FirstOrDefaultAsync();
        }

        public async Task<Likes> GetLikesById(int id)
        {
            return await context.Likes.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> UpdateLikes(Likes like)
        {
            context.Update(like);
            return await Save();
        }
        public async Task<bool> LikesExistsByFollow(string follow)
        {
            return await context.Likes.AnyAsync(u => u.Follow == follow);
        }

        public async Task<bool> LikesExistsByID(int id)
        {
            return await context.Likes.AnyAsync(u => u.Id == id);
        }
    }
}
