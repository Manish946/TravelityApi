using AutoMapper;
using BackEnd_Travelity.Domain;
using BackEnd_Travelity.DTO.User_DTOModel;
using BackEnd_Travelity.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Travelity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //mapping and services init
        private readonly IUserService UserService;
        private readonly IMapper mapper;
        public UserController(IUserService _UserService, IMapper _mapper) // DI
        {
            UserService = _UserService;
            mapper = _mapper;
        }
        // Get All Users from the database.
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserModel>))] // This only helps API request cleaner and easy to read the types.
        public async Task<IActionResult> GetAllUsers()
        {
            // Mapping User to UserModel DTO.
            var Users = mapper.Map<List<UserModel>>(await UserService.GetAllUsers());
            // If Mode state is invalid return bad request with model state.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //else return users
            return Ok(Users);
        }

        //get user by id
        [HttpGet("Id/{Id}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]

        public async Task<IActionResult> GetUserById(int Id)
        {
            //If user doesnt exists return problem
            if (!await UserService.UserExistsByID(Id))
            {
                return NotFound();
            }
            // Mapping User to UserModel
            var User = mapper.Map<UserModel>(await UserService.GetUserById(Id));
            //if the given data doesnt correlate with the data in our database return problem
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            //else return the user
            else
            {
                return Ok(User);
            }
        }
        //get user by username
        [HttpGet("Username/{Username}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]

        public async Task<IActionResult> GetUserByUsername(string Username)
        {
            //If user doesnt exists return problem
            if (!await UserService.UserExistsByUsername(Username))
            {
                return NotFound();
            }
            // Mapping User to UserModel
            var User = mapper.Map<UserModel>(await UserService.GetByUserName(Username));
            //if the given data doesnt correlate with the data in our database return problem
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            //else return the user
            else
            {
                return Ok(User);
            }
        }

        //create user
        [HttpPost()]
        // Created Response Type
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        // For id and User name parameter add [FromQuery]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserModel UserCreate)
        {
            //If the data in our create a user function is empty return problem
            if (UserCreate == null)
            {
                return BadRequest(ModelState);
            }
            //If data is not valid return problem
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // then CreateUserModel is mapped to User.
            var User = mapper.Map<User>(UserCreate);
            //If a user exists by the given username return problem
            if (await UserService.UserExistsByUsername(User.Username))
            {
                ModelState.AddModelError("", "User already exists.");
                return StatusCode(409, ModelState);
            }
            //If a user exists by the given email return problem
            if (await UserService.UserExistsByEmail(User.Email))
            {
                ModelState.AddModelError("", "Email already exists.");
                return StatusCode(409, ModelState);
            }
            //If there was a problem in our database return problem
            if (!await UserService.CreateUser(User))
            {
                ModelState.AddModelError("", "Something went wrong while Saving");
                return StatusCode(500, ModelState);
            }
            //Else create user
            return Ok("Successfully Created");
        }

        //update user
        [HttpPut("Update/{Id}")]
        // Created Response Type
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        // For id and User name parameter add [FromQuery]
        public async Task<IActionResult> UpdateUser(int Id, [FromBody] UpdateUserModel updatedUser)
        {
            //If the data in our update a user function is empty nor is not changed return problem
            if (updatedUser == null)
            {
                return BadRequest(ModelState);
            }
            //If user id is not the same with the given data return problem
            if (Id != updatedUser.Id)
            {
                return BadRequest(ModelState);

            }
            //If user doesnt exists in our database return problem
            if (!await UserService.UserExistsByID(Id))
            {
                return NotFound();
            }
            //If user model is not valid return problem
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            //Mapping of user to update new user data
            var User = mapper.Map<User>(updatedUser);
            //If problem with our database return problem
            if (!await UserService.UpdateUser(User))
            {
                ModelState.AddModelError("", "Something went wrong updating User");
                return StatusCode(500, ModelState);
            }
            //else return user
            return NoContent();
        }

        //delete user
        [HttpDelete("Delete/{Id}")]
        // Created Response Type
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        // For id and User name parameter add [FromQuery]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            //Cheking if user to delete exists else return problem
            if (!await UserService.UserExistsByID(Id))
            {
                return NotFound();
            }


            //If user doesnt exists in our database return problem
            var UserToDelete = await UserService.GetUserById(Id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //If our database has problem return problem
            if (!await UserService.DeleteUser(UserToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting User");
                return StatusCode(500, ModelState);

            }
            //return deleted user
            return NoContent();

        }


        // USER Friend EndPoints.

        // Get All User Friends from the database.
        [HttpGet("Friends/{Username}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserModel>))] // This only helps API request cleaner and easy to read the types.
        public async Task<IActionResult> GetUserFriends(string Username)
        {
            // Mapping User to UserModel DTO.
            var friends = mapper.Map<List<UserModel>>(await UserService.GetFriendByUsername(Username));
            // If Mode state is invalid return bad request with model state.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //else return users
            return Ok(friends);
        }

        // Get All User Friends from the database.
        [HttpGet("Friendslist/{Username}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserModel>))] // This only helps API request cleaner and easy to read the types.
        public async Task<IActionResult> GetUserFriendslist(string Username)
        {
            // Mapping User to UserModel DTO.
            var friends = mapper.Map<List<UserModel>>(await UserService.GetFriendByUsername(Username));
            // If Mode state is invalid return bad request with model state.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //else return users
            return Ok(friends);
        }


        // Get All User FriendRequest from the database.
        [HttpGet("FriendRequests/{Username}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserModel>))] // This only helps API request cleaner and easy to read the types.
        public async Task<IActionResult> GetUserFriendRequests(string Username)
        {
            // Mapping User to UserModel DTO.
            var friendRequests = mapper.Map<List<UserModel>>(await UserService.GetFriendRequestByUsername(Username));
            // If Mode state is invalid return bad request with model state.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //else return users
            return Ok(friendRequests);
        }
    }
}
