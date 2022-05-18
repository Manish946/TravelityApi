using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Repository.BudgetRepo;

namespace BackEnd_Travelity.Services.BudgetService
{
    public class BudgetService : IBudgetService
    {

        private readonly IBudgetRepository budgetRepo;

        public BudgetService(IBudgetRepository _budgetRepo)
        {
            budgetRepo = _budgetRepo;
        }

        public async Task<ICollection<Budget>> GetAllBudgets() => await budgetRepo.GetAllBudgets();
        public async Task<Budget> GetBudgetById(int id) => await budgetRepo.GetBudgetById(id);
        public async Task<bool> BudgetExistsByID(int id) => await budgetRepo.BudgetExistsByID(id);

        public async Task<bool> CreateBudget(Budget budget) => await budgetRepo.CreateBudget(budget);
        public async Task<bool> UpdateBudget(Budget budget) => await budgetRepo.UpdateBudget(budget);
        public async Task<bool> DeleteBudget(Budget budget) => await budgetRepo.DeleteBudget(budget);
    }
}
