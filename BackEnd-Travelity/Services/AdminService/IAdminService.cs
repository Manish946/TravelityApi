using BackEnd_Travelity.Domain;

namespace BackEnd_Travelity.Services.AdminService
{
    public interface IAdminService
    {
        Task<ICollection<Admin>> GetAllAdmins();
        Task<Admin> GetAdminById(int id);
        Task<bool> AdminExistsByID(int id);


        Task<bool> CreateAdmin(Admin admin);
        Task<bool> UpdateAdmin(Admin admin);
        Task<bool> DeleteAdmin(Admin admin);
    }
}
