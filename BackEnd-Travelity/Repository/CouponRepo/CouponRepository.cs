using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Environment;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_Travelity.Repository.CouponRepo
{
    public class CouponRepository : ICouponRepository
    {
        private readonly DatabaseContext context;
        public CouponRepository(DatabaseContext _context)
        {
            context = _context;
        }
        public async Task<bool> CreateCoupon(Coupon coupon)
        {
            await context.AddAsync(coupon);
            return await Save();
        }

        public async Task<bool> DeleteCoupon(Coupon coupon)
        {
            context.Remove(coupon);
            return await Save();
        }

        public async Task<ICollection<Coupon>> GetAllCoupons()
        {
            return await context.Coupon.ToListAsync();
        }

        public async Task<Coupon> GetCouponById(int id)
        {
            return await context.Coupon.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> UpdateCoupon(Coupon coupon)
        {
            context.Update(coupon);
            return await Save();
        }
        public async Task<bool> CouponExistsByID(int id)
        {
            return await context.Coupon.AnyAsync(u => u.Id == id);
        }
    }
}
