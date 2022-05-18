using BackEnd_Travelity.Domain;
using System.Linq.Expressions;

namespace BackEnd_Travelity.DTO
{
    public class CouponDTO
    {
        public int Id { get; set; }
        public List<int> Budget { get; set; }
        public List<int> User { get; set; }
        public string Title { get; set; }
        public double AmountPaid { get; set; }
        public static Expression<Func<Coupon, CouponDTO>> CouponDetails => Coupon => new()
        {
            Id = Coupon.Id,
            Budget = Coupon.Budgets.Select(x => x.Id).ToList(),
            User = Coupon.Users.Select(x => x.Id).ToList(),
            Title = Coupon.Title,
            AmountPaid = Coupon.AmountPaid,
        };
    }
}
