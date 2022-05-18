using AutoMapper;
using BackEnd_Travelity.Domain;
using BackEnd_Travelity.DTO.FriendRequest_DTOModel;
using BackEnd_Travelity.Services.FriendRequestService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Travelity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AdminCors")]
    public class FriendRequestController : Controller
    {
        private readonly IFriendRequestService FriendRequestService;
        private readonly IMapper mapper;
        public FriendRequestController(IFriendRequestService _FriendRequestService, IMapper _mapper)
        {
            FriendRequestService = _FriendRequestService;
            mapper = _mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<FriendRequest>))]
        public async Task<IActionResult> GetAllFriendRequests()
        {
            var FriendRequests = mapper.Map<List<FriendRequestModel>>(await FriendRequestService.GetAllFriendRequests());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(FriendRequests);
        }

        [HttpGet("Id/{Id}")]
        [ProducesResponseType(200, Type = typeof(FriendRequest))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetFriendRequestById(int Id)
        {
            if (!await FriendRequestService.FriendRequestExistsByID(Id))
            {
                return NotFound();
            }
            var FriendRequest = mapper.Map<FriendRequestModel>(await FriendRequestService.GetFriendRequestById(Id));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(FriendRequest);
            }
        }

        [HttpGet("Sender/{Name}")]
        [ProducesResponseType(200, Type = typeof(FriendRequest))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetFriendRequestBySender(string Name)
        {
            if (!await FriendRequestService.FriendRequestExistsBySender(Name))
            {
                return NotFound();
            }
            var FriendRequest = mapper.Map<List<FriendRequestModel>>(await FriendRequestService.GetByFriendRequestSender(Name));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(FriendRequest);
            }
        }

        [HttpGet("Receiver/{Name}")]
        [ProducesResponseType(200, Type = typeof(FriendRequest))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetFriendRequestByReceiver(string Name)
        {
            if (!await FriendRequestService.FriendRequestExistsByReceiver(Name))
            {
                return NotFound();
            }
            var FriendRequest = mapper.Map<List<FriendRequestModel>>(await FriendRequestService.GetByFriendRequestReceiver(Name));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(FriendRequest);
            }
        }


        [HttpPost()]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateFriendRequest([FromBody] FriendRequestModel FriendRequestCreate)
        {
            if (FriendRequestCreate == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var FriendRequest = mapper.Map<FriendRequest>(FriendRequestCreate);

            if (!await FriendRequestService.CreateFriendRequest(FriendRequest))
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
        public async Task<IActionResult> UpdateFriendRequest(int Id, [FromBody] UpdateFriendRequestModel updatedFriendRequest)
        {
            if (updatedFriendRequest == null)
            {
                return BadRequest(ModelState);
            }
            if (Id != updatedFriendRequest.Id)
            {
                return BadRequest(ModelState);

            }

            if (!await FriendRequestService.FriendRequestExistsByID(Id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var FriendRequest = mapper.Map<FriendRequest>(updatedFriendRequest);

            if (!await FriendRequestService.UpdateFriendRequest(FriendRequest))
            {
                ModelState.AddModelError("", "Something went wrong updating your FriendRequest");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("Delete/{Id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteFriendRequest(int Id)
        {
            if (!await FriendRequestService.FriendRequestExistsByID(Id))
            {
                return NotFound();
            }

            var FriendRequestToDelete = await FriendRequestService.GetFriendRequestById(Id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await FriendRequestService.DeleteFriendRequest(FriendRequestToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting your FriendRequest");
                return StatusCode(500, ModelState);

            }
            return NoContent();

        }
    }
}
