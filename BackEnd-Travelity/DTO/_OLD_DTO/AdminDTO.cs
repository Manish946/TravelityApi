using BackEnd_Travelity.Domain;
using System.Linq.Expressions;

namespace BackEnd_Travelity.DTO
{
    public class AdminDTO
    {
        public int Id { get; set; }
        public bool Yes_no { get; set; }
        public List<int> Group { get; set; }
        public List<int> User { get; set; }
        public static Expression<Func<Admin, AdminDTO>> AdminDetails => Admin => new()
        {
            Id = Admin.Id,
            Yes_no = Admin.Yes_no,
            Group = Admin.Groups.Select(x => x.Id).ToList(),
            User = Admin.Users.Select(x => x.Id).ToList(),
        };
    }
}
