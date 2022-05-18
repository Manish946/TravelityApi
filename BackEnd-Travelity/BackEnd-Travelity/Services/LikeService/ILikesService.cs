using BackEnd_Travelity.Domain;

namespace BackEnd_Travelity.Services.LikesService
{
    public interface ILikesService
    {
        Task<ICollection<Likes>> GetAllLikes();
        Task<Likes> GetLikesById(int id);
        Task<Likes> GetByLikesFollow(string follow);
        Task<bool> LikesExistsByFollow(string follow);
        Task<bool> LikesExistsByID(int id);

        Task<bool> CreateLikes(Likes likes);
        Task<bool> UpdateLikes(Likes likes);
        Task<bool> DeleteLikes(Likes likes);
    }
}
