using System.ComponentModel.DataAnnotations;


namespace BackEnd_Travelity.Domain
{
    public class Group : Super
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string GroupName { get; set; }
        public string Destination { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM dd yyyy}")]
        public string GroupAdmin { get; set; }
        public string GroupThumbnail { get; set; }          
        public DateTime CreatedTimeStamp { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Picture> Pictures { get; set; }
        public ICollection<Admin> Admins { get; set; }
        public ICollection<Chat> Chats { get; set; }
        public ICollection<Place> Places { get; set; }
    }
}
