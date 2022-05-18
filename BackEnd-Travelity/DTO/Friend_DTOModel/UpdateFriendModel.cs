namespace BackEnd_Travelity.DTO.Friend_DTOModel
{
    public class UpdateFriendModel
    {
        public int Id { get; set; } 
        public string User_Username { get; set; }


        public string Friend_Username { get; set; }

        public DateTime DateAdded { get; set; }

    }
}
