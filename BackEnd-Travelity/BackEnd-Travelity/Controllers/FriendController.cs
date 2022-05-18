using AutoMapper;
using BackEnd_Travelity.Domain;
using BackEnd_Travelity.DTO.Friend_DTOModel;
using BackEnd_Travelity.Services.FriendService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Travelity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AdminCors")]
    public class FriendController : ControllerBase
    {
        private readonly IFriendService FriendService;
        private readonly IMapper mapper;
        public FriendController(IFriendService _FriendService, IMapper _mapper)
        {
            FriendService = _FriendService;
            mapper = _mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Friend>))]
        public async Task<IActionResult> GetAllFriends()
        {
            var Friends = mapper.Map<List<FriendModel>>(await FriendService.GetAllFriends());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Friends);
        }

        [HttpGet("Id/{Id}")]
        [ProducesResponseType(200, Type = typeof(Friend))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetFriendById(int Id)
        {
            if (!await FriendService.FriendExistsByID(Id))
            {
                return NotFound();
            }
            var Friend = mapper.Map<FriendModel>(await FriendService.GetFriendById(Id));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(Friend);
            }
        }

        [HttpGet("Username/{Name}")]
        [ProducesResponseType(200, Type = typeof(Friend))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetFriendByName(string Name)
        {
            if (!await FriendService.FriendExistsByName(Name))
            {
                return NotFound();
            }
            var Friend = mapper.Map<FriendModel>(await FriendService.FriendExistsByName(Name));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(Friend);
            }
        }

        [HttpPost()]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateFriend([FromBody] FriendModel FriendCreate)
        {
            if (FriendCreate == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Friend = mapper.Map<Friend>(FriendCreate);

            if (!await FriendService.CreateFriend(Friend))
            {
                ModelState.AddModelError("", "Something went wrong while Saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");
        }

        [HttpPut("Update/{Id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateFriend(int Id, [FromBody] UpdateFriendModel updatedFriend)
        {
            if (updatedFriend == null)
            {
                return BadRequest(ModelState);
            }
            if (Id != updatedFriend.Id)
            {
                return BadRequest(ModelState);

            }

            if (!await FriendService.FriendExistsByID(Id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var Friend = mapper.Map<Friend>(updatedFriend);

            if (!await FriendService.UpdateFriend(Friend))
            {
                ModelState.AddModelError("", "Something went wrong updating your Friend");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("Delete/{Id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteFriend(int Id)
        {
            if (!await FriendService.FriendExistsByID(Id))
            {
                return NotFound();
            }

            var FriendToDelete = await FriendService.GetFriendById(Id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await FriendService.DeleteFriend(FriendToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting your Friend");
                return StatusCode(500, ModelState);

            }
            return NoContent();

        }
    }
}
