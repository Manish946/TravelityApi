using BackEnd_Travelity.Domain;

namespace BackEnd_Travelity.Repository.FriendRequestRepo
{
    public interface IFriendRequestRepository
    {
        Task<ICollection<FriendRequest>> GetAllFriendRequests();
        Task<FriendRequest> GetFriendRequestById(int id);
        Task<ICollection<FriendRequest>> GetByFriendRequestSender(string name);
        Task<ICollection<FriendRequest>> GetByFriendRequestReceiver(string name);
        Task<bool> FriendRequestExistsBySender(string name);
        Task<bool> FriendRequestExistsByReceiver(string name);
        Task<bool> FriendRequestExistsByID(int id);
        Task<bool> CreateFriendRequest(FriendRequest friendRequest);
        Task<bool> Save();
        Task<bool> UpdateFriendRequest(FriendRequest friendRequest);
        Task<bool> DeleteFriendRequest(FriendRequest friendRequest);
    }
}
