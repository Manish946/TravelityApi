using System.ComponentModel.DataAnnotations;

namespace BackEnd_Travelity.Domain
{
    public class Picture
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Image { get; set; }
        public int Likes { get; set; }
        public ICollection<User> Users { get; set; }
        public int CommentsFromUser { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public List<Group> Groups { get; set; }
        public List<Permission> Permissions { get; set; }
    }
}
