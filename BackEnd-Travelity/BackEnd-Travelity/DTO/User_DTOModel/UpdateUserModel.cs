namespace BackEnd_Travelity.DTO.User_DTOModel
{
    /// <summary>
    /// To Map our user model for Update user for a more smooth look when bug fixing
    /// </summary>
    public class UpdateUserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string About { get; set; }
        public string ProfilePicture { get; set; }
    }
}
