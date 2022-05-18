using BackEnd_Travelity.Domain;

namespace BackEnd_Travelity.Repository.PermissionRepo
{
    public interface IPermissionRepository
    {
        Task<ICollection<Permission>> GetAllPermissions();
        Task<Permission> GetPermissionById(int id);
        Task<bool> PermissionExistsByID(int id);
        Task<bool> CreatePermission(Permission permission);
        Task<bool> Save();
        Task<bool> UpdatePermission(Permission permission);
        Task<bool> DeletePermission(Permission permission);
    }
}
