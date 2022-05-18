using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Repository.GroupRepo;

namespace BackEnd_Travelity.Services.GroupService
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository groupRepo;

        public GroupService(IGroupRepository _groupRepo)
        {
            groupRepo = _groupRepo;
        }

        public async Task<ICollection<Group>> GetAllGroups() => await groupRepo.GetAllGroups();
        public async Task<Group> GetGroupById(int id) => await groupRepo.GetGroupById(id);
        public async Task<Group> GetGroupByName(string group_name) => await groupRepo.GetGroupByName(group_name);
        public async Task<bool> GroupExistsByName(string group_name) => await groupRepo.GroupExistsByName(group_name);
        public async Task<bool> GroupExistsByID(int id) => await groupRepo.GroupExistsByID(id);

        public async Task<bool> CreateGroup(Group group) => await groupRepo.CreateGroup(group);
        public async Task<bool> UpdateGroup(Group group) => await groupRepo.UpdateGroup(group);
        public async Task<bool> DeleteGroup(Group group) => await groupRepo.DeleteGroup(group);
    }
}
