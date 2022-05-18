using BackEnd_Travelity.Domain;

namespace BackEnd_Travelity.Repository.AdminRepo
{
    public interface IAdminRepository
    {
        Task<ICollection<Admin>> GetAllAdmins();
        Task<Admin> GetAdminById(int id);
        Task<bool> AdminExistsByID(int id);
        Task<bool> CreateAdmin(Admin admin);
        Task<bool> Save();
        Task<bool> DeleteAdmin(Admin admin);
        Task<bool> UpdateAdmin(Admin admin);
    }
}
