using BackEnd_Travelity.Domain;
using System.Linq.Expressions;

namespace BackEnd_Travelity.DTO
{
    public class BudgetDTO
    {
        public int Id { get; set; }
        public List<int> Group { get; set; }
        public List<int> User { get; set; }
        public List<int> AVBudget { get; set; }
        public List<int> BudgetReport { get; set; }
        public List<int> Coupon { get; set; }
        public string BudgetName { get; set; }
        public double BudgetNum { get; set; }
        public static Expression<Func<Budget, BudgetDTO>> BudgetDetails => Budget => new()
        {
            Id = Budget.Id,
            Group = Budget.Groups.Select(x => x.Id).ToList(),
            User = Budget.Users.Select(x => x.Id).ToList(),
            AVBudget = Budget.AVBudgets.Select(x => x.Id).ToList(),
            BudgetReport = Budget.BudgetReports.Select(x => x.Id).ToList(),
            Coupon = Budget.Coupons.Select(x => x.Id).ToList(),
            BudgetName = Budget.BudgetName,
            BudgetNum = Budget.BudgetNum,
        };
    }
}
