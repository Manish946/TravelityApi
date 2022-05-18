using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Repository.AdminRepo;

namespace BackEnd_Travelity.Services.AdminService
{
    public class AdminService : IAdminService
    {

        private readonly IAdminRepository adminRepo;

        public AdminService(IAdminRepository _adminRepo)
        {
            adminRepo = _adminRepo;
        }

        public async Task<ICollection<Admin>> GetAllAdmins() => await adminRepo.GetAllAdmins();
        public async Task<Admin> GetAdminById(int id) => await adminRepo.GetAdminById(id);
        public async Task<bool> AdminExistsByID(int id) => await adminRepo.AdminExistsByID(id);

        public async Task<bool> CreateAdmin(Admin admin) => await adminRepo.CreateAdmin(admin);
        public async Task<bool> UpdateAdmin(Admin admin) => await adminRepo.UpdateAdmin(admin);
        public async Task<bool> DeleteAdmin(Admin admin) => await adminRepo.DeleteAdmin(admin);
    }
}
