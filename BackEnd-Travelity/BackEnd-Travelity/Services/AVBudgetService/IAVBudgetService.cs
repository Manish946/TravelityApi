using BackEnd_Travelity.Domain;

namespace BackEnd_Travelity.Services.AVBudgetService
{
    public interface IAVBudgetService
    {
        Task<ICollection<AVBudget>> GetAllAVBudgets();
        Task<AVBudget> GetAVBudgetById(int id);
        Task<bool> AVBudgetExistsByID(int id);

        Task<bool> CreateAVBudget(AVBudget avBudget);
        Task<bool> UpdateAVBudget(AVBudget avBudget);
        Task<bool> DeleteAVBudget(AVBudget avBudget);
    }
}
