using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Environment;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_Travelity.Repository.BudgetRepo
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly DatabaseContext context;
        public BudgetRepository(DatabaseContext _context)
        {
            context = _context;
        }
        public async Task<bool> CreateBudget(Budget budget)
        {
            await context.AddAsync(budget);
            return await Save();
        }

        public async Task<bool> DeleteBudget(Budget budget)
        {
            context.Remove(budget);
            return await Save();
        }

        public async Task<ICollection<Budget>> GetAllBudgets()
        {
            return await context.Budget.ToListAsync();
        }

        public async Task<Budget> GetBudgetById(int id)
        {
            return await context.Budget.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> UpdateBudget(Budget budget)
        {
            context.Update(budget);
            return await Save();
        }
        public async Task<bool> BudgetExistsByID(int id)
        {
            return await context.Budget.AnyAsync(u => u.Id == id);
        }
    }
}
