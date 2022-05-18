using AutoMapper;
using BackEnd_Travelity.Domain;
using BackEnd_Travelity.DTO.MostVisited_DTOModel;
using BackEnd_Travelity.Services.MostVisitedService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Travelity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AdminCors")]
    public class MostVisitedController : ControllerBase
    {
        private readonly IMostVisitedService MostVisitedService;
        private readonly IMapper mapper;
        public MostVisitedController(IMostVisitedService _MostVisitedService, IMapper _mapper)
        {
            MostVisitedService = _MostVisitedService;
            mapper = _mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<MostVisited>))]
        public async Task<IActionResult> GetAllMostVisiteds()
        {
            var MostVisiteds = mapper.Map<List<MostVisitedModel>>(await MostVisitedService.GetAllMostVisiteds());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(MostVisiteds);
        }

        [HttpGet("Id/{Id}")]
        [ProducesResponseType(200, Type = typeof(MostVisited))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetMostVisitedById(int Id)
        {
            if (!await MostVisitedService.MostVisitedExistsByID(Id))
            {
                return NotFound();
            }
            var MostVisited = mapper.Map<MostVisitedModel>(await MostVisitedService.GetMostVisitedById(Id));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(MostVisited);
            }
        }

        [HttpPost()]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateMostVisited([FromBody] MostVisitedModel MostVisitedCreate)
        {
            if (MostVisitedCreate == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var MostVisited = mapper.Map<MostVisited>(MostVisitedCreate);

            if (!await MostVisitedService.CreateMostVisited(MostVisited))
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
        public async Task<IActionResult> UpdateMostVisited(int Id, [FromBody] UpdateMostVisitedModel updatedMostVisited)
        {
            if (updatedMostVisited == null)
            {
                return BadRequest(ModelState);
            }
            if (Id != updatedMostVisited.Id)
            {
                return BadRequest(ModelState);

            }

            if (!await MostVisitedService.MostVisitedExistsByID(Id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var MostVisited = mapper.Map<MostVisited>(updatedMostVisited);

            if (!await MostVisitedService.UpdateMostVisited(MostVisited))
            {
                ModelState.AddModelError("", "Something went wrong updating your MostVisited");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("Delete/{Id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteMostVisited(int Id)
        {
            if (!await MostVisitedService.MostVisitedExistsByID(Id))
            {
                return NotFound();
            }

            var MostVisitedToDelete = await MostVisitedService.GetMostVisitedById(Id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await MostVisitedService.DeleteMostVisited(MostVisitedToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting your MostVisited");
                return StatusCode(500, ModelState);

            }
            return NoContent();

        }
    }
}
