using BackEnd_Travelity.Domain;

namespace BackEnd_Travelity.Repository.GroupRepo
{
    public interface IGroupRepository
    {
        Task<ICollection<Group>> GetAllGroups();
        Task<Group> GetGroupById(int id);
        Task<Group> GetGroupByName(string groupName);
        Task<bool> GroupExistsByName(string groupName);
        Task<bool> GroupExistsByID(int id);
        Task<bool> CreateGroup(Group group);
        Task<bool> Save();
        Task<bool> UpdateGroup(Group group);
        Task<bool> DeleteGroup(Group group);
    }
}
