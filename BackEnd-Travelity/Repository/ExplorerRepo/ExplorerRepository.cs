using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Environment;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_Travelity.Repository.ExplorerRepo
{
    public class ExplorerRepository : IExplorerRepository
    {
        private readonly DatabaseContext context;
        public ExplorerRepository(DatabaseContext _context)
        {
            context = _context;
        }
        public async Task<bool> CreateExplorer(Explorer explorer)
        {
            await context.AddAsync(explorer);
            return await Save();
        }

        public async Task<bool> DeleteExplorer(Explorer explorer)
        {
            context.Remove(explorer);
            return await Save();
        }

        public async Task<ICollection<Explorer>> GetAllExplorers()
        {
            return await context.Explorer.ToListAsync();

        }

        public async Task<Explorer> GetExplorerById(int id)
        {
            return await context.Explorer.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
        public async Task<bool> ExplorerExistsByID(int id)
        {
            return await context.Explorer.AnyAsync(u => u.Id == id);
        }
    }
}
