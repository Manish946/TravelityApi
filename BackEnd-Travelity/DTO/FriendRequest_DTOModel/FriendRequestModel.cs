using BackEnd_Travelity.Domain;

namespace BackEnd_Travelity.DTO.FriendRequest_DTOModel
{
    public class FriendRequestModel
    {
       
        public int Id { get; set; }
       
        public string Sender { get; set; }
      

        public string Receiver { get; set; }

        public RequestStatus Status { get; set; }
    }
}
