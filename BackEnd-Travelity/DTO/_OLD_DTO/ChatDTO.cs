using BackEnd_Travelity.Domain;
using System.Linq.Expressions;

namespace BackEnd_Travelity.DTO
{
    public class ChatDTO
    {
        public int Id { get; set; }
        public string Messeage { get; set; }
        public List<int> User { get; set; }
        public List<int> Group { get; set; }
        public static Expression<Func<Chat, ChatDTO>> ChatDetails => Chat => new()
        {
            Id = Chat.Id,
            Messeage = Chat.Messeage,
            User = Chat.Users.Select(x => x.Id).ToList(),
            Group = Chat.Groups.Select(x => x.Id).ToList(),
        };
    }
}
