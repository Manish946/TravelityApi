using BackEnd_Travelity.Domain;

namespace BackEnd_Travelity.Repository.LikeRepo
{
    public interface ILikeRepo
    {
        Task<ICollection<Likes>> GetAllLikes();
        Task<Likes> GetLikesById(int id);
        Task<Likes> GetByLikesFollow(string follow);
        Task<bool> LikesExistsByFollow(string follow);
        Task<bool> LikesExistsByID(int id);
        Task<bool> CreateLikes(Likes like);
        Task<bool> Save();
        Task<bool> UpdateLikes(Likes like);
        Task<bool> DeleteLikes(Likes like);
    }
}
