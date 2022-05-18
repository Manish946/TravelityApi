using BackEnd_Travelity.Domain;
using BackEnd_Travelity.Repository.PlaceRepo;

namespace BackEnd_Travelity.Services.PlaceService
{
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository placeRepo;

        public PlaceService(IPlaceRepository _placeRepo)
        {
            placeRepo = _placeRepo;
        }

        public async Task<ICollection<Place>> GetAllPlaces() => await placeRepo.GetAllPlaces();
        public async Task<Place> GetPlaceById(int id) => await placeRepo.GetPlaceById(id);
        public async Task<Place> GetByPlaceCountry(string country) => await placeRepo.GetByPlaceCountry(country);
        public async Task<bool> PlaceExistsByCountry(string country) => await placeRepo.PlaceExistsByCountry(country);
        public async Task<bool> PlaceExistsByID(int id) => await placeRepo.PlaceExistsByID(id);

    }
}
