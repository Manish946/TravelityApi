using BackEnd_Travelity.Domain;
using System.Linq.Expressions;

namespace BackEnd_Travelity.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string About { get; set; }
        public string ProfilePicture { get; set; }
        public bool Status { get; set; }
        public List<int> Reminder { get; set; }
        public List<int> Like { get; set; }
        public List<int> Groups { get; set; }
        public List<int> Admins { get; set; }
        public List<int> Chats { get; set; }
        public List<int> Comments { get; set; }
        public List<int> Pictures { get; set; }
        public List<int> Friends { get; set; }
        public List<int> AVBudgets { get; set; }
        public static Expression<Func<User, UserDTO>> UserDetails => User => new()
        {
            Id = User.Id,
            Username = User.Username,
            FirstName = User.FirstName,
            LastName = User.LastName,
            FullName = User.Fullname,
            Email = User.Email,
            Password = User.Password,
            About = User.About,
            ProfilePicture = User.ProfilePicture,
            Status = User.Status,
            Reminder = User.Reminders.Select(x => x.Id).ToList(),
            Groups = User.Groups.Select(x => x.Id).ToList(),
            Admins = User.Admins.Select(x => x.Id).ToList(),
            Chats = User.Chats.Select(x => x.Id).ToList(),
            Comments = User.Comments.Select(x => x.Id).ToList(),
            Pictures = User.Pictures.Select(x => x.Id).ToList(),
            Friends = User.Friends.Select(x => x.Id).ToList(),
            AVBudgets = User.AVBudgets.Select(x => x.Id).ToList(),

        };
    }
}
