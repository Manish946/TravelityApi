using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Environment;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_Travelity.Repository.AVBudgetRepo
{
    public class AVBudgetRepository : IAVBudgetRepository
    {
        private readonly DatabaseContext context;
        public AVBudgetRepository(DatabaseContext _context)
        {
            context = _context;
        }
        public async Task<bool> CreateAVBudget(AVBudget avbudget)
        {
            await context.AddAsync(avbudget);
            return await Save();
        }

        public async Task<bool> DeleteAVBudget(AVBudget avbudget)
        {
            context.Remove(avbudget);
            return await Save();
        }

        public async Task<ICollection<AVBudget>> GetAllAVBudgets()
        {
            return await context.AVBudget.ToListAsync();
        }

        public async Task<AVBudget> GetAVBudgetById(int id)
        {
            return await context.AVBudget.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> UpdateAVBudget(AVBudget avbudget)
        {
            context.Update(avbudget);
            return await Save();
        }
        public async Task<bool> AVBudgetExistsByID(int id)
        {
            return await context.AVBudget.AnyAsync(u => u.Id == id);
        }
    }
}
