using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Repository.FriendRequestRepo;

namespace BackEnd_Travelity.Services.FriendRequestService
{
    public class FriendRequestService:IFriendRequestService
    {
        private readonly IFriendRequestRepository FriendRequestRepo;

        public FriendRequestService(IFriendRequestRepository _friendRepo)
        {
            FriendRequestRepo = _friendRepo;
        }
        public async Task<ICollection<FriendRequest>> GetAllFriendRequests() => await FriendRequestRepo.GetAllFriendRequests();
        public async Task<FriendRequest> GetFriendRequestById(int id) => await FriendRequestRepo.GetFriendRequestById(id);
        public async Task<ICollection<FriendRequest>> GetByFriendRequestSender(string name) => await FriendRequestRepo.GetByFriendRequestSender(name);
        public async Task<ICollection<FriendRequest>> GetByFriendRequestReceiver(string name) => await FriendRequestRepo.GetByFriendRequestReceiver(name);
        public async Task<bool> FriendRequestExistsByID(int id) => await FriendRequestRepo.FriendRequestExistsByID(id);
        public async Task<bool> FriendRequestExistsBySender(string name) => await FriendRequestRepo.FriendRequestExistsBySender(name);
        public async Task<bool> FriendRequestExistsByReceiver(string name) => await FriendRequestRepo.FriendRequestExistsByReceiver(name);

        public async Task<bool> CreateFriendRequest(FriendRequest FriendRequest) => await FriendRequestRepo.CreateFriendRequest(FriendRequest);
        public async Task<bool> UpdateFriendRequest(FriendRequest FriendRequest) => await FriendRequestRepo.UpdateFriendRequest(FriendRequest);
        public async Task<bool> DeleteFriendRequest(FriendRequest FriendRequest) => await FriendRequestRepo.DeleteFriendRequest(FriendRequest);


    }
}
