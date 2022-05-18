using System.ComponentModel.DataAnnotations;

namespace BackEnd_Travelity.Domain
{
    public class AVBudget : Super
    {
        [Key]
        public int Id { get; set; }
        public List<Budget> Budgets { get; set; }
        public List<User> Users { get; set; }
        [Required]
        public double Available { get; set; }
    }
}
