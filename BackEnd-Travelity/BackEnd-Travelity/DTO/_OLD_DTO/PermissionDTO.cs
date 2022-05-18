using BackEnd_Travelity.Domain;
using System.Linq.Expressions;

namespace BackEnd_Travelity.DTO
{
    public class PermissionDTO
    {
        public int Id { get; set; }
        public List<int> Picture { get; set; }
        public bool Yes_no { get; set; }
        public List<int> Explorer { get; set; }
        public List<int> MostVisited { get; set; }
        public static Expression<Func<Permission, PermissionDTO>> PermissionDetails => Permission => new()
        {
            Id = Permission.Id,
            Picture = Permission.Picture.Select(x => x.Id).ToList(),
            Yes_no = Permission.Yes_no,
            Explorer = Permission.Explorer.Select(x => x.Id).ToList(),
            MostVisited = Permission.MostVisited.Select(x => x.Id).ToList(),
        };
    }
}
