using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Environment;
using Microsoft.EntityFrameworkCore;


namespace BackEnd_Travelity.Repository.MostVisitedRepo
{
    public class MostVisitedRepository : IMostVisitedRepository
    {
        private readonly DatabaseContext context;
        public MostVisitedRepository(DatabaseContext _context)
        {
            context = _context;
        }
        public async Task<bool> CreateMostVisited(MostVisited mostVisited)
        {
            await context.AddAsync(mostVisited);
            return await Save();
        }

        public async Task<bool> DeleteMostVisited(MostVisited mostVisited)
        {
            context.Remove(mostVisited);
            return await Save();
        }

        public async Task<ICollection<MostVisited>> GetAllMostVisiteds()
        {
            return await context.MostVisited.ToListAsync();
        }

        public Task<MostVisited> GetMostVisitedById(int id)
        {
            return context.MostVisited.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> UpdateMostVisited(MostVisited mostVisited)
        {
            context.Update(mostVisited);
            return await Save();
        }
        public async Task<bool> MostVisitedExistsByID(int id)
        {
            return await context.MostVisited.AnyAsync(u => u.Id == id);
        }
    }
}
