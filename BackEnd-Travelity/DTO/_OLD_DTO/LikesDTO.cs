using BackEnd_Travelity.Domain;
using System.Linq.Expressions;

namespace BackEnd_Travelity.DTO
{
    public class LikesDTO
    {
        public int Id { get; set; }
        public string Follow { get; set; }
        public bool Yes_No { get; set; }
        public List<int> Users { get; set; }
        public static Expression<Func<Likes, LikesDTO>> LikeDetails => Likes => new()
        {
            Id = Likes.Id,
            Follow = Likes.Follow,
            Yes_No = Likes.Yes_No,
            Users = Likes.Users.Select(x => x.Id).ToList(),
        };
    }
}
