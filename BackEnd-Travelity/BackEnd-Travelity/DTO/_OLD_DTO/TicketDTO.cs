using BackEnd_Travelity.Domain;
using System.Linq.Expressions;

namespace BackEnd_Travelity.DTO
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public List<int> Users { get; set; }
        public static Expression<Func<Ticket, TicketDTO>> TicketDetails => Ticket => new()
        {
            Id = Ticket.Id,
            Title = Ticket.Title,
            Image = Ticket.Image,
            Users = Ticket.Users.Select(x => x.Id).ToList(),
        };
    }
}
