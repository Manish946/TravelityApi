using BackEnd_Travelity.Domain;

namespace BackEnd_Travelity.Repository.PlaceRepo
{
    public interface IPlaceRepository
    {
        Task<ICollection<Place>> GetAllPlaces();
        Task<Place> GetPlaceById(int id);
        Task<Place> GetByPlaceCountry(string country);
        Task<bool> PlaceExistsByCountry(string country);
        Task<bool> PlaceExistsByID(int id);
    }
}
