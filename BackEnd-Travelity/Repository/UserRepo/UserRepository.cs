using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Environment;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_Travelity.Repository.UserRepo
{
    public class UserRepository : IUserRepository
    {
        // Data base context to use in Dependency Injection. It will prevents over calling or repeating database to use data.
        private readonly DatabaseContext context;
        // Using IMapper nuGet to map model to DTO model.
        // private IMapper mapper;
        public UserRepository(DatabaseContext _context) // Dependency Injection 
                                                        // Dependency Injection (DI) is a software design pattern that allows us to develop loosely coupled code.
        {
            context = _context;
            // mapper = _mapper;
        }

        //Create user
        public async Task<bool> CreateUser(User user)
        {
            //Wating to get user data to create our user
            await context.AddAsync(user);
            //Crypting our users password
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            //Return user
            return await Save();
        }

        //Delete user
        public async Task<bool> DeleteUser(User user)
        {
            //Remove our users data
            context.Remove(user);
            //Return removed user
            return await Save();
        }

        //Get all users in our database
        public async Task<ICollection<User>> GetAllUsers()
        {
            //Return all users
            return await context.User.ToListAsync();
        }

        //Get single user by id
        public async Task<User> GetUserById(int id)
        {
            // Get User where User ID is input ID.
            return await context.User.Where(u => u.Id == id).FirstOrDefaultAsync();

        }

        //Get single user by Username
        public async Task<User> GetByUserName(string username)
        {
            // Get User where User name is input User name.
            return await context.User.Where(u => u.Username == username).FirstOrDefaultAsync();
        }

        //Update user
        public async Task<bool> UpdateUser(User user)
        {
            //Get updated user data
            context.Update(user);
            //return new user data
            return await Save();
        }

        //If Username is taken
        public async Task<bool> UserExistsByUsername(string username)
        {
            //If username already is in our database return problem else return user
            return await context.User.AnyAsync(u => u.Username == username);
        }

        //User Status
        public async Task<bool> UserStatus()
        {
            //If user is on our app change status from false to true or from true to false if they log-of
            return await context.User.AnyAsync(u => u.Status);
        }

        //Check if user exist in our database by id 
        public async Task<bool> UserExistsByID(int id)
        {
            //Check if user is in our datbase else return problem
            return await context.User.AnyAsync(u => u.Id == id);
        }

        //Check if email is already in use
        public async Task<bool> UserExistsByEmail(string email)
        {
            //Else return user
            return await context.User.AnyAsync(u => u.Email == email);
        }
        // make if username or email existed method.

        //Save the given or deleted data
        public async Task<bool> Save()
        {
            //Updateing our database
            var saved = await context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        //To encrypt our users password
        public User Login(User AuthUser)
        {
            //Getting the users credentials to find if password is encrypted
            var user = context.User.SingleOrDefault(x => x.Username == AuthUser.Username);
            //if its not encrypt data and change the password in our database
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(AuthUser.Password, user.Password);
            //If password is encrypted and the user is trying to login decrypt the password and encrypt after login
            if (isValidPassword)
            {
                return user;
            }
            return null;
        }

        // Get User Get Users Friends.
        public async Task<ICollection<User>> GetFriendByUsername(string username)
        {
            // Get all friends that has user_username as Current user.
            var friends = await context.Friend.Where(friend=> friend.User_Username == username).ToListAsync();
            // New List to hold list of friends.
            ICollection<User> users = new List<User>();
            // loops until friends count.
            for (int i = 0; i < friends.Count(); i++)
            {
                // Get users by user name with Friends_username and add it to the list.
                var friend = await context.User.Where(user=>user.Username == friends[i].Friend_Username).FirstOrDefaultAsync();
                users.Add(friend);
            }
            // Return Current users Friends.
            return users;
        }

        public async Task<ICollection<User>> GetFriendRequestByUsername(string username)
        {
            // Get All user friend requests;

            var FriendRequests = await context.FriendRequest.Where(friendRequest => friendRequest.Receiver == username && friendRequest.Status == 0).ToListAsync();

            ICollection<User> users = new List<User>();
            // loops until friends count.
            for (int i = 0; i < FriendRequests.Count(); i++)
            {
                // Get users by user name with Friends_username and add it to the list.
                var friend = await context.User.Where(user => user.Username == FriendRequests[i].Sender).FirstOrDefaultAsync();
                users.Add(friend);
            }
            // Return Current users Friends.
            return users;

        }

        public async Task<ICollection<User>> GetUsersFriendList(string username)
        {
            // Get all friends that has user_username as Current user.
            var friends = await context.Friend.Where(friend => friend.User_Username == username).ToListAsync();
            // New List to hold list of friends.
            ICollection<User> users = new List<User>();
            // loops until friends count.
            for (int i = 0; i < friends.Count(); i++)
            {
                // Get users by user name with Friends_username and add it to the list.
                var friend = await context.User.Where(user => user.Username == friends[i].Friend_Username).FirstOrDefaultAsync();
                users.Add(friend);
            }
            // Return Current users Friends.
            return users;
        }
    }
}
