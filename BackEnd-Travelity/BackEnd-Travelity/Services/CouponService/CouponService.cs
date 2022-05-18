using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Repository.CouponRepo;

namespace BackEnd_Travelity.Services.CouponService
{
    public class CouponService : ICouponService
    {
        private readonly ICouponRepository couponRepo;

        public CouponService(ICouponRepository _couponRepo)
        {
            couponRepo = _couponRepo;
        }

        public async Task<ICollection<Coupon>> GetAllCoupons() => await couponRepo.GetAllCoupons();
        public async Task<Coupon> GetCouponById(int id) => await couponRepo.GetCouponById(id);
        public async Task<bool> CouponExistsByID(int id) => await couponRepo.CouponExistsByID(id);

        public async Task<bool> CreateCoupon(Coupon coupon) => await couponRepo.CreateCoupon(coupon);
        public async Task<bool> UpdateCoupon(Coupon coupon) => await couponRepo.UpdateCoupon(coupon);
        public async Task<bool> DeleteCoupon(Coupon coupon) => await couponRepo.DeleteCoupon(coupon);

    }
}
