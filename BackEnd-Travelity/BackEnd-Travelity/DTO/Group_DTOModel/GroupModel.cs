
namespace BackEnd_Travelity.DTO.Group_DTOModel
{
    public class GroupModel
    {
        public int Id { get; set; }
        public string Group_name { get; set; }
        public string Group_description { get; set; }
        public DateTime Date { get; set; }
        public bool IsAdmin { get; set; }
    }
}
