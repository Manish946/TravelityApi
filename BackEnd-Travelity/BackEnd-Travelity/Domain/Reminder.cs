using System.ComponentModel.DataAnnotations;

namespace BackEnd_Travelity.Domain
{
    public class Reminder : Super
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Item { get; set; }
        public bool Yes_No { get; set; }
        public List<User> Users { get; set; }

    }
}
