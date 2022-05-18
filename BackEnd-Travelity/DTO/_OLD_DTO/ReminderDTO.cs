using BackEnd_Travelity.Domain;
using System.Linq.Expressions;

namespace BackEnd_Travelity.DTO
{
    public class ReminderDTO
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public bool Yes_No { get; set; }
        public List<int> users { get; set; }
        public static Expression<Func<Reminder, ReminderDTO>> ReminderDetails => Reminder => new()
        {
            Id = Reminder.Id,
            Item = Reminder.Item,
            Yes_No = Reminder.Yes_No,
            users = Reminder.Users.Select(x => x.Id).ToList(),
        };
    }
}
