using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Environment;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_Travelity.Repository.CommentRepo
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DatabaseContext context;
        public CommentRepository(DatabaseContext _context)
        {
            context = _context;
        }
        public async Task<bool> CreateComment(Comment comment)
        {
            await context.AddAsync(comment);
            return await Save();
        }

        public async Task<bool> DeleteComment(Comment comment)
        {
            context.Remove(comment);
            return await Save();
        }

        public async Task<ICollection<Comment>> GetAllComments()
        {
            return await context.Comment.ToListAsync();
        }

        public async Task<Comment> GetCommentById(int id)
        {
            return await context.Comment.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
        public async Task<bool> CommentExistsByID(int id)
        {
            return await context.Comment.AnyAsync(u => u.Id == id);
        }
    }
}
