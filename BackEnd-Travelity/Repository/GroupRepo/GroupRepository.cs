using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Environment;
using Microsoft.EntityFrameworkCore;


namespace BackEnd_Travelity.Repository.GroupRepo
{
    public class GroupRepository : IGroupRepository
    {
        private readonly DatabaseContext context;
        public GroupRepository(DatabaseContext _context)
        {
            context = _context;
        }
        public async Task<bool> CreateGroup(Group group)
        {
            await context.AddAsync(group);
            return await Save();
        }

        public async Task<bool> DeleteGroup(Group group)
        {
            context.Remove(group);
            return await Save();
        }

        public async Task<ICollection<Group>> GetAllGroups()
        {
            return await context.Group.ToListAsync();
        }

        public async Task<Group> GetGroupById(int id)
        {
            return await context.Group.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Group> GetGroupByName(string groupName)
        {
            return await context.Group.Where(n => n.Group_name == groupName).FirstOrDefaultAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> UpdateGroup(Group group)
        {
            context.Update(group);
            return await Save();
        }
        public async Task<bool> GroupExistsByName(string groupName)
        {
            return await context.Group.AnyAsync(u => u.Group_name == groupName);
        }

        public async Task<bool> GroupExistsByID(int id)
        {
            return await context.Group.AnyAsync(u => u.Id == id);
        }
    }
}
