using BackEnd_Travelity.Domain;

namespace BackEnd_Travelity.Repository.CommentRepo
{
    public interface ICommentRepository
    {
        Task<ICollection<Comment>> GetAllComments();
        Task<Comment> GetCommentById(int id);
        Task<bool> CommentExistsByID(int id);
        Task<bool> CreateComment(Comment comment);
        Task<bool> Save();
        Task<bool> DeleteComment(Comment comment);
    }
}
