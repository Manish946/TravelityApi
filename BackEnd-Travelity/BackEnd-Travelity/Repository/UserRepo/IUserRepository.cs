using BackEnd_Travelity.Domain;

namespace BackEnd_Travelity.Repository.UserRepo
{
    public interface IUserRepository
    {
        Task<ICollection<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> GetByUserName(string username);
        Task<bool> UserExistsByUsername(string username);
        Task<bool> UserExistsByID(int id);
        Task<bool> UserExistsByEmail(string email);
        Task<bool> CreateUser(User user);
        Task<bool> Save();
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(User user);
        // User Chat Interfaces
        Task<ICollection<User>> GetFriendByUsername(string username);
        Task<ICollection<User>> GetUsersFriendList(string username);
        Task<ICollection<User>> GetFriendRequestByUsername(string username);
        User Login(User authUser);
    }
}
