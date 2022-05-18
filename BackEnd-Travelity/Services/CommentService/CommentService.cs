using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Repository.CommentRepo;

namespace BackEnd_Travelity.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository commentRepo;

        public CommentService(ICommentRepository _commentRepo)
        {
            commentRepo = _commentRepo;
        }

        public async Task<ICollection<Comment>> GetAllComments() => await commentRepo.GetAllComments();
        public async Task<Comment> GetCommentById(int id) => await commentRepo.GetCommentById(id);
        public async Task<bool> CommentExistsByID(int id) => await commentRepo.CommentExistsByID(id);

        public async Task<bool> CreateComment(Comment comment) => await commentRepo.CreateComment(comment);
        public async Task<bool> DeleteComment(Comment comment) => await commentRepo.DeleteComment(comment);
    }

}
