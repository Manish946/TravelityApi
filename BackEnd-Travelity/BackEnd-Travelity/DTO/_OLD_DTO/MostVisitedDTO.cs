using BackEnd_Travelity.Domain;
using System.Linq.Expressions;

namespace BackEnd_Travelity.DTO
{
    public class MostVisitedDTO
    {
        public int Id { get; set; }
        public List<int> Places { get; set; }
        public List<int> Permissions { get; set; }
        public List<int> Explorers { get; set; }
        public static Expression<Func<MostVisited, MostVisitedDTO>> MostVisitedDetails => MostVisited => new()
        {
            Id = MostVisited.Id,
            Places = MostVisited.Places.Select(x => x.Id).ToList(),
            Permissions = MostVisited.Permissions.Select(x => x.Id).ToList(),
            Explorers = MostVisited.Explorer.Select(x => x.Id).ToList(),
        };
    }
}
