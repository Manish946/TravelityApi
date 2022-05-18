using BackEnd_Travelity.Domain;
using BackEnd_Travelity.DTO;
using BackEnd_Travelity.Environment;

using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BackEnd_Travelity.Repository.InterfaceRepo
{
    public class UserRepo : IUserRepo
    {
        private readonly DatabaseContext _context;
        public UserRepo(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<bool> create(UserDTO UserDetails)
        {
            if(_context.User.Any(x => x.Username == UserDetails.Username))
            {
                throw new ApplicationException("Username " + UserDetails.Username + " is already taken");
            }
            if (_context.User.Any(x => x.Email == UserDetails.Email))
            {
                throw new ApplicationException("This " + UserDetails.Email+ " is already in use");
            }
            _context.User.Add(new User()
            {
                Id = UserDetails.Id,
                Username = UserDetails.Username,
                FirstName = UserDetails.FirstName,
                LastName = UserDetails.LastName,
                Email = UserDetails.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(UserDetails.Password),
                About = UserDetails.About,
                ProfilePicture = UserDetails.ProfilePicture,
                Status = UserDetails.Status,
            });
            return await _context.SaveChangesAsync() != 0;
        }
        public async Task<ActionResult<UserDTO>> delete(int id)
        {
            User DeleteUser = await _context.User.FindAsync(id);
            if (DeleteUser != null)
            {
                _context.User.Remove(DeleteUser);
                await _context.SaveChangesAsync();

            }
            return DeleteUser == null ? new NotFoundResult() : new OkResult();
        }
        public async Task<ActionResult<User>> update(User user)
        {
            User UpdateUser = await _context.User.FindAsync(user.Id);
            if (UpdateUser != null)
            {
                if (UpdateUser.Username != user.Username) { UpdateUser.Username = user.Username; }
                if (UpdateUser.FirstName != user.FirstName) { UpdateUser.FirstName = user.FirstName;}
                if (UpdateUser.Email != user.Email) { UpdateUser.Email = user.Email;}
                List<Reminder> RemidnerToUpdate = _context.Reminder.Include(User => user.Reminders).ToList();

                RemidnerToUpdate.ForEach(Reminder => { Reminder.Users.Remove(UpdateUser); });

                user.Reminders.ToList().ForEach(Reminder => { Reminder AddReminder = _context.Reminder.Include(a => a.Users).SingleOrDefault(i => i.Id == Reminder.Id); AddReminder.Users.Add(UpdateUser); });

                _context.User.Add(UpdateUser);
                await _context.SaveChangesAsync();
                return new OkResult();
            }
            return new NotFoundResult();
        }
        public async Task<ActionResult> getUserById(int id)
        {
            var context = await _context.User.Select(a => new
            {
                id = a.Id,
                username = a.Username,
                fullname = a.Fullname,
                email = a.Email,
                about = a.About,
                profilePicture = a.ProfilePicture,
                status = a.Status,
                reminder = a.Reminders.Select(a => new{ a.Item, a.Yes_No }),
                group = a.Groups.Select(a => new { a.Id, a.Group_name }),
            }).SingleOrDefaultAsync(i => i.id == id);
            return new OkObjectResult(context);
        }
        public async Task<User> getUserByUsername(string username)
        {
            return await _context.User.Where(user => user.Username == username).FirstOrDefaultAsync();
        }
        public async Task<ActionResult> getUsers()
        {
            var context = await _context.User.Select(a => new
            {
                id = a.Id,
                username = a.Username,
                fullname = a.Fullname,
                email = a.Email,
                about = a.About,
                profilePicture = a.ProfilePicture,
                status = a.Status,
                reminder = a.Reminders.Select(a => new { a.Item, a.Yes_No }),
                group = a.Groups.Select(a => new { a.Id, a.Group_name }),
                picture = a.Pictures.Select(a => a.Id),

            }).ToListAsync();
            return new OkObjectResult(context);
        }
        public User login(User AuthUser)
        {
            var user = _context.User.SingleOrDefault(x => x.Username == AuthUser.Username);
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(AuthUser.Password, user.Password);
            if (isValidPassword)
            {
                return user;
            }
            return null;
        }
    }
}
