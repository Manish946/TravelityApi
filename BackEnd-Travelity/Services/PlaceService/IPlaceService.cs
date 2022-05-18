using BackEnd_Travelity.Domain;

namespace BackEnd_Travelity.Services.PlaceService
{
    public interface IPlaceService
    {
        Task<ICollection<Place>> GetAllPlaces();
        Task<Place> GetPlaceById(int id);
        Task<Place> GetByPlaceCountry(string country);
        Task<bool> PlaceExistsByCountry(string country);
        Task<bool> PlaceExistsByID(int id);
    }
}
