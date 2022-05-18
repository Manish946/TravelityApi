using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Environment;
using Microsoft.EntityFrameworkCore;


namespace BackEnd_Travelity.Repository.ReminderRepo
{
    public class ReminderRepository : IReminderRepository
    {
        private readonly DatabaseContext context;
        public ReminderRepository(DatabaseContext _context)
        {
            context = _context;
        }
        public async Task<bool> CreateReminder(Reminder user)
        {
            await context.AddAsync(user);
            return await Save();
        }

        public async Task<bool> DeleteReminder(Reminder reminder)
        {
            context.Remove(reminder);
            return await Save();

        }

        public async Task<ICollection<Reminder>> GetAllReminders()
        {
            return await context.Reminder.ToListAsync();
        }

        public async Task<Reminder> GetByReminderItem(string item)
        {
            return await context.Reminder.Where(n => n.Item == item).FirstOrDefaultAsync();
        }

        public async Task<Reminder> GetReminderById(int id)
        {
            return await context.Reminder.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> UpdateReminder(Reminder reminder)
        {
            context.Update(reminder);
            return await Save();
        }
        public async Task<bool> ReminderExistsByItem(string item)
        {
            return await context.Reminder.AnyAsync(u => u.Item == item);
        }

        public async Task<bool> ReminderExistsByID(int id)
        {
            return await context.User.AnyAsync(u => u.Id == id);
        }
    }
}
