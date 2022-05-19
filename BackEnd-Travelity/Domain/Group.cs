using System.ComponentModel.DataAnnotations;


namespace BackEnd_Travelity.Domain
{
    public class Group : Super
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Group_name { get; set; }
        public string Group_description { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM dd yyyy}")]
        public DateTime Date { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Picture> Pictures { get; set; }
        public ICollection<Admin> Admins { get; set; }
        public ICollection<Chat> Chats { get; set; }
        public ICollection<Place> Places { get; set; }
        public bool IsAdmin { get; set; }
    }
}
