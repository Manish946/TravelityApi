using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Environment;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_Travelity.Repository.BudgetReportRepo
{
    public class BudgetReportRepository : IBudgetReportRepository
    {
        private readonly DatabaseContext context;
        public BudgetReportRepository(DatabaseContext _context)
        {
            context = _context;
        }

        public async Task<bool> CreateBudgetReport(BudgetReport budgetReport)
        {
            await context.AddAsync(budgetReport);
            return await Save();
        }

        public async Task<bool> DeleteBudgetReport(BudgetReport budgetReport)
        {
            context.Remove(budgetReport);
            return await Save();
        }

        public async Task<ICollection<BudgetReport>> GetAllBudgetReports()
        {
            return await context.BudgetReport.ToListAsync();
        }

        public async Task<BudgetReport> GetBudgetReportById(int id)
        {
            return await context.BudgetReport.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> UpdateBudgetReport(BudgetReport budgetReport)
        {
            context.Update(budgetReport);
            return await Save();
        }
        public async Task<bool> BudgetReportExistsByID(int id)
        {
            return await context.BudgetReport.AnyAsync(u => u.Id == id);
        }
    }
}
