using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Repository.UserRepo;

namespace BackEnd_Travelity.Services.UserService
{
    public class UserService : IUserService
    {
        //To connect to our user repository
        private readonly IUserRepository userRepo;

        public UserService(IUserRepository _userRepo)
        {
            userRepo = _userRepo;
        }
        /// <summary>
        /// Creating the functions/Task used in our user repository to Create,Update,Delete,GET ALL,GET by, Email, UserName or Id exist 
        /// </summary>

        public async Task<ICollection<User>> GetAllUsers() => await userRepo.GetAllUsers();
        public async Task<User> GetUserById(int id) => await userRepo.GetUserById(id);
        public async Task<User> GetByUserName(string username) => await userRepo.GetByUserName(username);
        public async Task<bool> UserExistsByUsername(string username) => await userRepo.UserExistsByUsername(username);
        public async Task<bool> UserExistsByID(int id) => await userRepo.UserExistsByID(id);
        public async Task<bool> UserExistsByEmail(string email) => await userRepo.UserExistsByEmail(email);

        public async Task<bool> CreateUser(User user) => await userRepo.CreateUser(user);
        public async Task<bool> UpdateUser(User user) => await userRepo.UpdateUser(user);
        public async Task<bool> DeleteUser(User user) => await userRepo.DeleteUser(user);

        public async Task<ICollection<User>> GetFriendByUsername(string username) => await userRepo.GetFriendByUsername(username);

        public async Task<ICollection<User>> GetFriendRequestByUsername(string username) => await userRepo.GetFriendRequestByUsername(username);

        public async Task<ICollection<User>> GetUsersFriendList(string username) => await userRepo.GetUsersFriendList(username);
    }
}
