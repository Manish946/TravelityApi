using BackEnd_Travelity.Domain;

namespace BackEnd_Travelity.Services.BudgetReportService
{
    public interface IBudgetReportService
    {
        Task<ICollection<BudgetReport>> GetAllBudgetReports();
        Task<BudgetReport> GetBudgetReportById(int id);
        Task<bool> BudgetReportExistsByID(int id);

        Task<bool> CreateBudgetReport(BudgetReport budgetReport);
        Task<bool> UpdateBudgetReport(BudgetReport budgetReport);
        Task<bool> DeleteBudgetReport(BudgetReport budgetReport);
    }
}
