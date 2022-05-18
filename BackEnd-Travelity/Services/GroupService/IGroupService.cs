using BackEnd_Travelity.Domain;

namespace BackEnd_Travelity.Services.GroupService
{
    public interface IGroupService
    {
        Task<ICollection<Group>> GetAllGroups();
        Task<Group> GetGroupById(int id);
        Task<Group> GetGroupByName(string group_name);
        Task<bool> GroupExistsByName(string group_name);
        Task<bool> GroupExistsByID(int id);

        Task<bool> CreateGroup(Group group);
        Task<bool> UpdateGroup(Group group);
        Task<bool> DeleteGroup(Group group);
    }
}
