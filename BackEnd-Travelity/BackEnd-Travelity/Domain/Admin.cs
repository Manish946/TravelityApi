using System.ComponentModel.DataAnnotations;

namespace BackEnd_Travelity.Domain
{
    public class Admin : Super
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public bool Yes_no { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
