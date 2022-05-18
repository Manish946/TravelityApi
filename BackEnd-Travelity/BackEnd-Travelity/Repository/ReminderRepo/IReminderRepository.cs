using BackEnd_Travelity.Domain;

namespace BackEnd_Travelity.Repository.ReminderRepo
{
    public interface IReminderRepository
    {
        Task<ICollection<Reminder>> GetAllReminders();
        Task<Reminder> GetReminderById(int id);
        Task<Reminder> GetByReminderItem(string item);
        Task<bool> ReminderExistsByItem(string item);
        Task<bool> ReminderExistsByID(int id);
        Task<bool> CreateReminder(Reminder user);
        Task<bool> Save();
        Task<bool> UpdateReminder(Reminder reminder);
        Task<bool> DeleteReminder(Reminder reminder);
    }
}
