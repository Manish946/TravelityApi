using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Repository.PermissionRepo;

namespace BackEnd_Travelity.Services.PermissionService
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository permissionRepo;

        public PermissionService(IPermissionRepository _permissionRepo)
        {
            permissionRepo = _permissionRepo;
        }

        public async Task<ICollection<Permission>> GetAllPermissions() => await permissionRepo.GetAllPermissions();
        public async Task<Permission> GetPermissionById(int id) => await permissionRepo.GetPermissionById(id);
        public async Task<bool> PermissionExistsByID(int id) => await permissionRepo.PermissionExistsByID(id);

        public async Task<bool> CreatePermission(Permission permission) => await permissionRepo.CreatePermission(permission);
        public async Task<bool> UpdatePermission(Permission permission) => await permissionRepo.UpdatePermission(permission);
        public async Task<bool> DeletePermission(Permission permission) => await permissionRepo.DeletePermission(permission);
    }
}
