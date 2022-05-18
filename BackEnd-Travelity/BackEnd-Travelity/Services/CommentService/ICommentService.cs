using BackEnd_Travelity.Domain;

namespace BackEnd_Travelity.Services.CommentService
{
    public interface ICommentService
    {
        Task<ICollection<Comment>> GetAllComments();
        Task<Comment> GetCommentById(int id);
        Task<bool> CommentExistsByID(int id);

        Task<bool> CreateComment(Comment comment);
        Task<bool> DeleteComment(Comment comment);
    }
}
