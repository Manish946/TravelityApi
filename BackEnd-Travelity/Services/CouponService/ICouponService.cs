using BackEnd_Travelity.Domain;

namespace BackEnd_Travelity.Services.CouponService
{
    public interface ICouponService
    {
        Task<ICollection<Coupon>> GetAllCoupons();
        Task<Coupon> GetCouponById(int id);
        Task<bool> CouponExistsByID(int id);


        Task<bool> CreateCoupon(Coupon coupon);
        Task<bool> UpdateCoupon(Coupon coupon);
        Task<bool> DeleteCoupon(Coupon coupon);
    }
}
