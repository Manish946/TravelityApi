using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Environment;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_Travelity.Repository.AdminRepo
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DatabaseContext context;
        public AdminRepository(DatabaseContext _context)
        {
            context = _context;
        }

        public async Task<bool> CreateAdmin(Admin admin)
        {
            await context.AddAsync(admin);
            return await Save();
        }

        public async Task<bool> DeleteAdmin(Admin admin)
        {
            context.Remove(admin);
            return await Save();
        }

        public async Task<Admin> GetAdminById(int id)
        {
            return await context.Admin.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ICollection<Admin>> GetAllAdmins()
        {
            return await context.Admin.ToListAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> UpdateAdmin(Admin admin)
        {
            context.Update(admin);
            return await Save();
        }
        public async Task<bool> AdminExistsByID(int id)
        {
            return await context.Admin.AnyAsync(u => u.Id == id);
        }
    }
}
