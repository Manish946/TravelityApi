using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Environment;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_Travelity.Repository.PictureRepo
{
    public class PictureRepository : IPictureRepository
    {
        private readonly DatabaseContext context;
        public PictureRepository(DatabaseContext _context)
        {
            context = _context;
        }
        public async Task<bool> CreatePicture(Picture picture)
        {
            await context.AddAsync(picture);
            return await Save();

        }

        public async Task<bool> DeletePicture(Picture picture)
        {
            context.Remove(picture);
            return await Save();
        }

        public async Task<ICollection<Picture>> GetAllPictures()
        {
            return await context.Picture.ToListAsync();
        }

        public async Task<Picture> GetPictureById(int id)
        {
            return await context.Picture.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> PictureExistsByID(int id)
        {
            return await context.Picture.AnyAsync(u => u.Id == id);
        }
    }
}
