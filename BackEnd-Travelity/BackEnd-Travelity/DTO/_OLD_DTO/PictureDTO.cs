using BackEnd_Travelity.Domain;
using System.Linq.Expressions;

namespace BackEnd_Travelity.DTO
{
    public class PictureDTO
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int Likes { get; set; }
        public List<int> users { get; set; }
        public int CommentsFromUser { get; set; }
        public List<int> groups { get; set; }
        public List<int> comments { get; set; }
        public List<int> permissions { get; set; }
        public static Expression<Func<Picture, PictureDTO>> PictureDetails => Picture => new()
        {
            Id = Picture.Id,
            Image = Picture.Image,
            Likes = Picture.Likes,
            users = Picture.Users.Select(x => x.Id).ToList(),
            CommentsFromUser = Picture.CommentsFromUser,
            groups = Picture.Groups.Select(x => x.Id).ToList(),
            comments = Picture.Comments.Select(x => x.Id).ToList(),
            permissions = Picture.Permissions.Select(x => x.Id).ToList(),
        };
    }
}
