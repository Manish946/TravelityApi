using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BackEnd_Travelity.Domain
{
    public class User : Super
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [JsonIgnore]
        public string Fullname { get { return FirstName + " " + LastName; } }
        public string Email { get; set; }
        [Required]
        [StringLength(128, MinimumLength = 8, ErrorMessage = "The passwords length must be 8 characters long")]
        public string Password { get; set; }
        public string About { get; set; }
        public string ProfilePicture { get; set; }
        public bool Status { get; set; }
        public ICollection<Reminder> Reminders { get; set; }
        public ICollection<Friend> Friends { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<Likes> Likes { get; set; }
        public List<Group> Groups { get; set; }
        public List<Admin> Admins { get; set; }
        public List<Chat> Chats { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Picture> Pictures { get; set; }
        public ICollection<AVBudget> AVBudgets { get; set; }
    }
}
