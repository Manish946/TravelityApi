using System.ComponentModel.DataAnnotations;

namespace BackEnd_Travelity.Domain
{
    public class MostVisited : Super
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Place> Places { get; set; }
        public ICollection<Permission> Permissions { get; set; }
        public List<Explorer> Explorer { get; set; }
    }
}
