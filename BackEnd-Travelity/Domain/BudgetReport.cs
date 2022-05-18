using System.ComponentModel.DataAnnotations;

namespace BackEnd_Travelity.Domain
{
    public class BudgetReport : Super
    {
        [Key]
        public int Id { get; set; }
        public List<Budget> Budgets { get; set; }
        public List<User> Users { get; set; }
        public int TotalPaid { get; set; }
        public int TotalReceived { get; set; }
    }
}
