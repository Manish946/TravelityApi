using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Repository.FriendRepo;

namespace BackEnd_Travelity.Services.FriendService
{
    public class FriendService : IFriendService
    {
        private readonly IFriendRepository friendRepo;

        public FriendService(IFriendRepository _friendRepo)
        {
            friendRepo = _friendRepo;
        }

        public async Task<ICollection<Friend>> GetAllFriends() => await friendRepo.GetAllFriends();
        public async Task<Friend> GetFriendById(int id) => await friendRepo.GetFriendById(id);
        public async Task<Friend> GetByFriendName(string name) => await friendRepo.GetByFriendName(name);
        public async Task<bool> FriendExistsByName(string name) => await friendRepo.FriendExistsByName(name);
        public async Task<bool> FriendExistsByID(int id) => await friendRepo.FriendExistsByID(id);

        public async Task<bool> CreateFriend(Friend friend) => await friendRepo.CreateFriend(friend);
        public async Task<bool> UpdateFriend(Friend friend) => await friendRepo.UpdateFriend(friend);
        public async Task<bool> DeleteFriend(Friend friend) => await friendRepo.DeleteFriend(friend);
    }
}
