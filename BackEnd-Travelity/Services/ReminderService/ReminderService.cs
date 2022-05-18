using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Repository.ReminderRepo;

namespace BackEnd_Travelity.Services.ReminderService
{
    public class ReminderService : IReminderService
    {
        private readonly IReminderRepository reminderRepo;

        public ReminderService(IReminderRepository _reminderRepo)
        {
            reminderRepo = _reminderRepo;
        }

        public async Task<ICollection<Reminder>> GetAllReminders() => await reminderRepo.GetAllReminders();
        public async Task<Reminder> GetReminderById(int id) => await reminderRepo.GetReminderById(id);
        public async Task<Reminder> GetByReminderItem(string item) => await reminderRepo.GetByReminderItem(item);
        public async Task<bool> ReminderExistsByItem(string item) => await reminderRepo.ReminderExistsByItem(item);
        public async Task<bool> ReminderExistsByID(int id) => await reminderRepo.ReminderExistsByID(id);

        public async Task<bool> CreateReminder(Reminder reminder) => await reminderRepo.CreateReminder(reminder);
        public async Task<bool> UpdateReminder(Reminder reminder) => await reminderRepo.UpdateReminder(reminder);
        public async Task<bool> DeleteReminder(Reminder reminder) => await reminderRepo.DeleteReminder(reminder);
    }
}
