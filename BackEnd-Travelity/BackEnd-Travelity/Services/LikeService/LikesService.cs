using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Repository.LikeRepo;

namespace BackEnd_Travelity.Services.LikesService
{
    public class LikesService : ILikesService
    {
        private readonly ILikeRepo liksRepo;

        public LikesService(ILikeRepo _likesRepo)
        {
            liksRepo = _likesRepo;
        }

        public async Task<ICollection<Likes>> GetAllLikes() => await liksRepo.GetAllLikes();
        public async Task<Likes> GetLikesById(int id) => await liksRepo.GetLikesById(id);
        public async Task<Likes> GetByLikesFollow(string follow) => await liksRepo.GetByLikesFollow(follow);
        public async Task<bool> LikesExistsByFollow(string follow) => await liksRepo.LikesExistsByFollow(follow);
        public async Task<bool> LikesExistsByID(int id) => await liksRepo.LikesExistsByID(id);

        public async Task<bool> CreateLikes(Likes likes) => await liksRepo.CreateLikes(likes);
        public async Task<bool> UpdateLikes(Likes likes) => await liksRepo.UpdateLikes(likes);
        public async Task<bool> DeleteLikes(Likes likes) => await liksRepo.DeleteLikes(likes);
    }
}
