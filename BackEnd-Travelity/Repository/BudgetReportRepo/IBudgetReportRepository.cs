using BackEnd_Travelity.Domain;

namespace BackEnd_Travelity.Repository.BudgetReportRepo
{
    public interface IBudgetReportRepository
    {
        Task<ICollection<BudgetReport>> GetAllBudgetReports();
        Task<BudgetReport> GetBudgetReportById(int id);
        Task<bool> BudgetReportExistsByID(int id);
        Task<bool> CreateBudgetReport(BudgetReport budgetReport);
        Task<bool> Save();
        Task<bool> UpdateBudgetReport(BudgetReport budgetReport);
        Task<bool> DeleteBudgetReport(BudgetReport budgetReport);
    }
}
