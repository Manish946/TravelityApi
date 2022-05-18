using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Repository.AVBudgetRepo;

namespace BackEnd_Travelity.Services.AVBudgetService
{
    public class AVBudgetService : IAVBudgetService
    {
        private readonly IAVBudgetRepository avbudgetRepo;

        public AVBudgetService(IAVBudgetRepository _avbudgetRepo)
        {
            avbudgetRepo = _avbudgetRepo;
        }

        public async Task<ICollection<AVBudget>> GetAllAVBudgets() => await avbudgetRepo.GetAllAVBudgets();
        public async Task<AVBudget> GetAVBudgetById(int id) => await avbudgetRepo.GetAVBudgetById(id);
        public async Task<bool> AVBudgetExistsByID(int id) => await avbudgetRepo.AVBudgetExistsByID(id);

        public async Task<bool> CreateAVBudget(AVBudget user) => await avbudgetRepo.CreateAVBudget(user);
        public async Task<bool> UpdateAVBudget(AVBudget user) => await avbudgetRepo.UpdateAVBudget(user);
        public async Task<bool> DeleteAVBudget(AVBudget user) => await avbudgetRepo.DeleteAVBudget(user);

    }
}
