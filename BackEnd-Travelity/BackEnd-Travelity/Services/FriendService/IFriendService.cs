using BackEnd_Travelity.Domain;

namespace BackEnd_Travelity.Services.FriendService
{
    public interface IFriendService
    {
        Task<ICollection<Friend>> GetAllFriends();
        Task<Friend> GetFriendById(int id);
        Task<Friend> GetByFriendName(string name);
        Task<bool> FriendExistsByName(string name);
        Task<bool> FriendExistsByID(int id);

        Task<bool> CreateFriend(Friend friend);
        Task<bool> UpdateFriend(Friend friend);
        Task<bool> DeleteFriend(Friend friend);
    }
}
