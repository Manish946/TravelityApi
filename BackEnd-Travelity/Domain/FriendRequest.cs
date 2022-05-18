using System.ComponentModel.DataAnnotations;

namespace BackEnd_Travelity.Domain
{
    public enum RequestStatus { Sent = 0, Accepted = 1, Declined = 2 }
    public class FriendRequest
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Sender { get; set; }
        [Required]

        public string Receiver { get; set; }
        [Required]
        [EnumDataType(typeof(RequestStatus))]
        public RequestStatus Status { get; set; }
        public List<User> Users { get; set; }
    }
}
