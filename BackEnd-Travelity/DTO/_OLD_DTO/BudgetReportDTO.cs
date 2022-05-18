using BackEnd_Travelity.Domain;
using System.Linq.Expressions;

namespace BackEnd_Travelity.DTO
{
    public class BudgetReportDTO
    {
        public int Id { get; set; }
        public List<int> Budget { get; set; }
        public List<int> User { get; set; }
        public int TotalPaid { get; set; }
        public int TotalReceived { get; set; }
        public static Expression<Func<BudgetReport, BudgetReportDTO>> BudgetReportDetails => BudgetReport => new()
        {
            Id = BudgetReport.Id,
            Budget = BudgetReport.Budgets.Select(x => x.Id).ToList(),
            User = BudgetReport.Users.Select(x => x.Id).ToList(),
            TotalPaid = BudgetReport.TotalPaid,
            TotalReceived = BudgetReport.TotalReceived,
        };
    }
}
