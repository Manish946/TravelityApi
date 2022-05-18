using BackEnd_Travelity.Domain;
using System.Linq.Expressions;

namespace BackEnd_Travelity.DTO
{
    public class GroupDTO
    {
        public int Id { get; set; }
        public string Group_name { get; set; }
        public string Group_description { get; set; }
        public DateTime Date { get; set; }
        public List<int> Users { get; set; }
        public List<int> Places { get; set; }
        public List<int> Chats { get; set; }
        public List<int> Admins { get; set; }
        public bool IsAdmin { get; set; }

        public static Expression<Func<Group, GroupDTO>> GroupDetails => Group => new()
        {
            Id = Group.Id,
            Group_name = Group.Group_name,
            Group_description = Group.Group_description,
            Date = Group.Date,
            Users = Group.Users.Select(x => x.Id).ToList(),
            Places = Group.Places.Select(x => x.Id).ToList(),
            Chats = Group.Chats.Select(x => x.Id).ToList(),
            Admins = Group.Admins.Select(x => x.Id).ToList(),
            IsAdmin = Group.IsAdmin,

        };
    }
}
