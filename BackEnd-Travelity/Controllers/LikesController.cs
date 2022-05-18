using AutoMapper;
using BackEnd_Travelity.Domain;
using BackEnd_Travelity.DTO.Likes_DTOModel;
using BackEnd_Travelity.Services.LikesService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Travelity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AdminCors")]
    public class LikesController : ControllerBase
    {
        private readonly ILikesService LikesService;
        private readonly IMapper mapper;
        public LikesController(ILikesService _LikesService, IMapper _mapper)
        {
            LikesService = _LikesService;
            mapper = _mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Likes>))]
        public async Task<IActionResult> GetAllLikes()
        {
            var Likess = mapper.Map<List<LikesModel>>(await LikesService.GetAllLikes());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Likess);
        }

        [HttpGet("Id/{Id}")]
        [ProducesResponseType(200, Type = typeof(Likes))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetLikesById(int Id)
        {
            if (!await LikesService.LikesExistsByID(Id))
            {
                return NotFound();
            }
            var Likes = mapper.Map<LikesModel>(await LikesService.GetLikesById(Id));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(Likes);
            }
        }

        [HttpGet("Follow/{Follow}")]
        [ProducesResponseType(200, Type = typeof(Likes))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetLikesByFollow(string Follow)
        {
            if (!await LikesService.LikesExistsByFollow(Follow))
            {
                return NotFound();
            }
            var Likes = mapper.Map<LikesModel>(await LikesService.LikesExistsByFollow(Follow));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(Likes);
            }
        }

        [HttpPost()]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateLikes([FromBody] LikesModel LikesCreate)
        {
            if (LikesCreate == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Likes = mapper.Map<Likes>(LikesCreate);

            if (!await LikesService.CreateLikes(Likes))
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
        public async Task<IActionResult> UpdateLikes(int Id, [FromBody] UpdateLikesModel updatedLikes)
        {
            if (updatedLikes == null)
            {
                return BadRequest(ModelState);
            }
            if (Id != updatedLikes.Id)
            {
                return BadRequest(ModelState);

            }

            if (!await LikesService.LikesExistsByID(Id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var Likes = mapper.Map<Likes>(updatedLikes);

            if (!await LikesService.UpdateLikes(Likes))
            {
                ModelState.AddModelError("", "Something went wrong updating your Likes");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("Delete/{Id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteLikes(int Id)
        {
            if (!await LikesService.LikesExistsByID(Id))
            {
                return NotFound();
            }

            var LikesToDelete = await LikesService.GetLikesById(Id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await LikesService.DeleteLikes(LikesToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting your Likes");
                return StatusCode(500, ModelState);

            }
            return NoContent();

        }
    }
}
