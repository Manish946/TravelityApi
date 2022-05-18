using System.ComponentModel.DataAnnotations;

namespace BackEnd_Travelity.Domain
{
    public class Comment : Super
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string CommentText { get; set; }
        public List<User> Users { get; set; }
        public List<Picture> Pictures { get; set; }
    }
}
