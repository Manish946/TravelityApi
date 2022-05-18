using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Environment;
using Microsoft.EntityFrameworkCore;


namespace BackEnd_Travelity.Repository.PermissionRepo
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly DatabaseContext context;
        public PermissionRepository(DatabaseContext _context)
        {
            context = _context;
        }
        public async Task<bool> CreatePermission(Permission permission)
        {
            await context.AddAsync(permission);
            return await Save();
        }

        public async Task<bool> DeletePermission(Permission permission)
        {
            context.Remove(permission);
            return await Save();
        }

        public async Task<ICollection<Permission>> GetAllPermissions()
        {
            return await context.Permission.ToListAsync();
        }

        public async Task<Permission> GetPermissionById(int id)
        {
            return await context.Permission.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> UpdatePermission(Permission permission)
        {
            context.Update(permission);
            return await Save();
        }
        public async Task<bool> PermissionExistsByID(int id)
        {
            return await context.Permission.AnyAsync(u => u.Id == id);
        }
    }
}
