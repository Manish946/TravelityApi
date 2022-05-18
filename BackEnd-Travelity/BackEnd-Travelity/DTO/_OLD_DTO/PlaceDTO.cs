using BackEnd_Travelity.Domain;
using System.Linq.Expressions;

namespace BackEnd_Travelity.DTO
{
    public class PlaceDTO
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public List<int> Groups { get; set; }
        public List<int> Explorers { get; set; }
        public List<int> MostVisiteds { get; set; }
        public static Expression<Func<Place, PlaceDTO>> PlaceDetails => Place => new()
        {
            Id = Place.Id,
            Country = Place.Country,
            Groups = Place.Groups.Select(x => x.Id).ToList(),
            Explorers = Place.Explorers.Select(x => x.Id).ToList(),
            MostVisiteds = Place.MostVisiteds.Select(x => x.Id).ToList(),
        };
    }
}
