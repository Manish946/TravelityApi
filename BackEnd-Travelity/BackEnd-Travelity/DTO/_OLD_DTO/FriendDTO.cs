using BackEnd_Travelity.Domain;
using System.Linq.Expressions;

namespace BackEnd_Travelity.DTO
{
    public class FriendDTO
    {

        public int Id { get; set; }

        public string User_Username { get; set; }


        public string Friend_Username { get; set; }


        public DateTime DateAdded { get; set; }
        public List<User> Users { get; set; }
    }
}
