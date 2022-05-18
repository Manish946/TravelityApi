using System.ComponentModel.DataAnnotations;

namespace BackEnd_Travelity.Domain
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Picture> Picture { get; set; }
        [Required]
        public bool Yes_no { get; set; }
        public List<Explorer> Explorer { get; set; }
        public List<MostVisited> MostVisited { get; set; }
    }
}
