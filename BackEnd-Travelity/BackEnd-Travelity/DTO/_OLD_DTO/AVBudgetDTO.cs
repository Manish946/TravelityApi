using BackEnd_Travelity.Domain;
using System.Linq.Expressions;

namespace BackEnd_Travelity.DTO
{
    public class AVBudgetDTO
    {
        public int Id { get; set; }
        public List<int> Budget { get; set; }
        public List<int> User { get; set; }
        public double Available { get; set; }
        public static Expression<Func<AVBudget, AVBudgetDTO>> AVBudgetDetauls => AVBudget => new()
        {
            Id = AVBudget.Id,
            Budget = AVBudget.Budgets.Select(x => x.Id).ToList(),
            User = AVBudget.Users.Select(x => x.Id).ToList(),
            Available = AVBudget.Available,
        };
    }
}
