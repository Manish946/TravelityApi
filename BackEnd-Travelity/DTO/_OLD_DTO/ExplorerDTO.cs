using BackEnd_Travelity.Domain;
using System.Linq.Expressions;

namespace BackEnd_Travelity.DTO
{
    public class ExplorerDTO
    {
        public int Id { get; set; }
        public List<int> Places { get; set; }
        public List<int> Permissions { get; set; }
        public List<int> MostVisited { get; set; }

        public static Expression<Func<Explorer, ExplorerDTO>> ExplorerDetails => Explorer => new()
        {
            Id = Explorer.Id,
            Places = Explorer.Places.Select(x => x.Id).ToList(),
            Permissions = Explorer.Permissions.Select(x => x.Id).ToList(),
            MostVisited = Explorer.MostVisited.Select(x => x.Id).ToList(),
        };
    }
}
