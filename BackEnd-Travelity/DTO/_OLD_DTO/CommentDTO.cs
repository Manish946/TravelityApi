using BackEnd_Travelity.Domain;
using System.Linq.Expressions;

namespace BackEnd_Travelity.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public List<int> User { get; set; }
        public List<int> Picture { get; set; }
        public static Expression<Func<Comment, CommentDTO>> CommentDetails => Comment => new()
        {
            Id = Comment.Id,
            CommentText = Comment.CommentText,
            User = Comment.Users.Select(x => x.Id).ToList(),
            Picture = Comment.Pictures.Select(x => x.Id).ToList(),
        };
    }
}
