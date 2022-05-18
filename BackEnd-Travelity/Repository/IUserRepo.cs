using BackEnd_Travelity.Domain;
using BackEnd_Travelity.DTO;

using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Travelity.Repository.InterfaceRepo
{
    public interface IUserRepo
    {
        Task<bool> create(UserDTO userDetails);
        Task<ActionResult<UserDTO>> delete(int id);
        Task<ActionResult<User>> update(User user);
        Task<ActionResult> getUserById(int id);
        Task<User> getUserByUsername(string Username);
        Task<ActionResult> getUsers();
        User login(User authUser);
    }
}
