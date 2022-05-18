using System.ComponentModel.DataAnnotations;

namespace BackEnd_Travelity.Domain
{
    public class Budget : Super
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<User> Users { get; set; }
        public List<AVBudget> AVBudgets { get; set; }
        public List<BudgetReport> BudgetReports { get; set; }
        public List<Coupon> Coupons { get; set; }
        public string BudgetName { get; set; }
        public double BudgetNum { get; set; }

    }
}
