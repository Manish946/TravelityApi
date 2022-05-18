using System.ComponentModel.DataAnnotations;

namespace BackEnd_Travelity.Domain
{
    public class Friend : Super
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string User_Username { get; set; }
        [Required]

        public string Friend_Username { get; set; }
        [Required]

        public DateTime DateAdded { get; set; }
        public List<User> Users { get; set; }
    }
}
