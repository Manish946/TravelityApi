using BackEnd_Travelity.Domain;

namespace BackEnd_Travelity.Repository.AVBudgetRepo
{
    public interface IAVBudgetRepository
    {
        Task<ICollection<AVBudget>> GetAllAVBudgets();
        Task<AVBudget> GetAVBudgetById(int id);
        Task<bool> AVBudgetExistsByID(int id);
        Task<bool> CreateAVBudget(AVBudget avbudget);
        Task<bool> Save();
        Task<bool> UpdateAVBudget(AVBudget avbudget);
        Task<bool> DeleteAVBudget(AVBudget avbudget);
    }
}
