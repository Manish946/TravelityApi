using System.ComponentModel.DataAnnotations;

namespace BackEnd_Travelity.Domain
{
    public class Coupon : Super
    {
        [Key]
        public int Id { get; set; }
        public List<Budget> Budgets { get; set; }
        public List<User> Users { get; set; }
        public string Title { get; set; }
        public double AmountPaid { get; set; }
    }
}
