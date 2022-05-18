using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Environment;
using Microsoft.EntityFrameworkCore;


namespace BackEnd_Travelity.Repository.TicketRepo
{
    public class TicketRepository : ITicketRepository
    {
        private readonly DatabaseContext context;
        public TicketRepository(DatabaseContext _context)
        {
            context = _context;
        }
        public async Task<bool> CreateTicket(Ticket ticket)
        {
            await context.AddAsync(ticket);
            return await Save();
        }

        public async Task<bool> DeleteTicket(Ticket ticket)
        {
            context.Remove(ticket);
            return await Save();
        }

        public async Task<ICollection<Ticket>> GetAllTickets()
        {
            return await context.Ticket.ToListAsync();
        }

        public async Task<Ticket> GetByTicketTitle(string title)
        {
            return await context.Ticket.Where(n => n.Title == title).FirstOrDefaultAsync();
        }

        public async Task<Ticket> GetTicketById(int id)
        {
            return await context.Ticket.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Save()
        {
            var saved = await context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<bool> UpdateTicket(Ticket ticket)
        {
            context.Update(ticket);
            return await Save();
        }
        public async Task<bool> TicketExistsByTitle(string title)
        {
            return await context.Ticket.AnyAsync(u => u.Title == title);
        }

        public async Task<bool> TicketExistsByID(int id)
        {
            return await context.Ticket.AnyAsync(u => u.Id == id);
        }
    }
}
