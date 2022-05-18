using BackEnd_Travelity.Domain;

namespace BackEnd_Travelity.Services.BudgetService
{
    public interface IBudgetService
    {
        Task<ICollection<Budget>> GetAllBudgets();
        Task<Budget> GetBudgetById(int id);
        Task<bool> BudgetExistsByID(int id);

        Task<bool> CreateBudget(Budget budget);
        Task<bool> UpdateBudget(Budget budget);
        Task<bool> DeleteBudget(Budget budget);
    }
}
