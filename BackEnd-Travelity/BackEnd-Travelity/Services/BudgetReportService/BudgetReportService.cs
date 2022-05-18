using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Repository.BudgetReportRepo;

namespace BackEnd_Travelity.Services.BudgetReportService
{
    public class BudgetReportService : IBudgetReportService
    {

        private readonly IBudgetReportRepository budgetReportRepo;

        public BudgetReportService(IBudgetReportRepository _budgetReportRepo)
        {
            budgetReportRepo = _budgetReportRepo;
        }

        public async Task<ICollection<BudgetReport>> GetAllBudgetReports() => await budgetReportRepo.GetAllBudgetReports();
        public async Task<BudgetReport> GetBudgetReportById(int id) => await budgetReportRepo.GetBudgetReportById(id);
        public async Task<bool> BudgetReportExistsByID(int id) => await budgetReportRepo.BudgetReportExistsByID(id);

        public async Task<bool> CreateBudgetReport(BudgetReport budgetReport) => await budgetReportRepo.CreateBudgetReport(budgetReport);
        public async Task<bool> UpdateBudgetReport(BudgetReport budgetReport) => await budgetReportRepo.UpdateBudgetReport(budgetReport);
        public async Task<bool> DeleteBudgetReport(BudgetReport budgetReport) => await budgetReportRepo.DeleteBudgetReport(budgetReport);
    }
}
