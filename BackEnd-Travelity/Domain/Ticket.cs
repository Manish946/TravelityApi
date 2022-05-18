using System.ComponentModel.DataAnnotations;

namespace BackEnd_Travelity.Domain
{
    public class Ticket : Super
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Image { get; set; }
        public List<User> Users { get; set; }
    }
}
