using System.ComponentModel.DataAnnotations;

namespace BackEnd_Travelity.Domain
{
    public class Place : Super
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Country { get; set; }
        public List<Group> Groups { get; set; }
        public List<Explorer> Explorers { get; set; }
        public List<MostVisited> MostVisiteds { get; set; }
    }
}
