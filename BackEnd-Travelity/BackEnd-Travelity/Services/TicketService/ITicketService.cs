using BackEnd_Travelity.Domain;

namespace BackEnd_Travelity.Services.TicketService
{
    public interface ITicketService
    {
        Task<ICollection<Ticket>> GetAllTickets();
        Task<Ticket> GetTicketById(int id);
        Task<Ticket> GetByTicketTitle(string title);
        Task<bool> TicketExistsByTitle(string title);
        Task<bool> TicketExistsByID(int id);

        Task<bool> CreateTicket(Ticket ticket);
        Task<bool> UpdateTicket(Ticket ticket);
        Task<bool> DeleteTicket(Ticket ticket);
    }
}
