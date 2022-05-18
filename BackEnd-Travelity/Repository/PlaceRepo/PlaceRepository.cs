using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Environment;
using Microsoft.EntityFrameworkCore;


namespace BackEnd_Travelity.Repository.PlaceRepo
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly DatabaseContext context;
        public PlaceRepository(DatabaseContext _context)
        {
            context = _context;
        }
        public async Task<ICollection<Place>> GetAllPlaces()
        {
            return await context.Place.ToListAsync();
        }

        public async Task<Place> GetByPlaceCountry(string country)
        {
            return await context.Place.Where(n => n.Country == country).FirstOrDefaultAsync();
        }

        public async Task<Place> GetPlaceById(int id)
        {
            return await context.Place.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> PlaceExistsByCountry(string country)
        {
            return await context.Place.AnyAsync(n => n.Country == country);
        }

        public async Task<bool> PlaceExistsByID(int id)
        {
            return await context.Place.AnyAsync(i => i.Id == id);
        }
    }
}
