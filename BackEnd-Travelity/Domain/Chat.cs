using System.ComponentModel.DataAnnotations;

namespace BackEnd_Travelity.Domain
{
    public class Chat : Super
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Messeage { get; set; }
        public ICollection<User> Users { get; set; }
        public List<Group> Groups { get; set; }
    }
}
