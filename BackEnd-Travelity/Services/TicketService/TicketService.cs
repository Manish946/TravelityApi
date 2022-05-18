using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Repository.TicketRepo;

namespace BackEnd_Travelity.Services.TicketService
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository ticketRepo;

        public TicketService(ITicketRepository _ticketRepo)
        {
            ticketRepo = _ticketRepo;
        }

        public async Task<ICollection<Ticket>> GetAllTickets() => await ticketRepo.GetAllTickets();
        public async Task<Ticket> GetTicketById(int id) => await ticketRepo.GetTicketById(id);
        public async Task<Ticket> GetByTicketTitle(string title) => await ticketRepo.GetByTicketTitle(title);
        public async Task<bool> TicketExistsByTitle(string title) => await ticketRepo.TicketExistsByTitle(title);
        public async Task<bool> TicketExistsByID(int id) => await ticketRepo.TicketExistsByID(id);

        public async Task<bool> CreateTicket(Ticket ticket) => await ticketRepo.CreateTicket(ticket);
        public async Task<bool> UpdateTicket(Ticket ticket) => await ticketRepo.UpdateTicket(ticket);
        public async Task<bool> DeleteTicket(Ticket ticket) => await ticketRepo.DeleteTicket(ticket);

    }
}
