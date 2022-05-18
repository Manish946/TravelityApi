using AutoMapper;
using BackEnd_Travelity.Domain;
using BackEnd_Travelity.DTO.Explorer_DTOModel;
using BackEnd_Travelity.Services.ExplorerService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Travelity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AdminCors")]
    public class ExplorerController : ControllerBase
    {

        private readonly IExplorerService ExplorerService;
        private readonly IMapper mapper;
        public ExplorerController(IExplorerService _ExplorerService, IMapper _mapper)
        {
            ExplorerService = _ExplorerService;
            mapper = _mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Explorer>))]
        public async Task<IActionResult> GetAllExplorers()
        {
            var Explorers = mapper.Map<List<ExplorerModel>>(await ExplorerService.GetAllExplorers());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Explorers);
        }

        [HttpGet("Id/{Id}")]
        [ProducesResponseType(200, Type = typeof(Explorer))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetExplorerById(int Id)
        {
            if (!await ExplorerService.ExplorerExistsByID(Id))
            {
                return NotFound();
            }
            var Explorer = mapper.Map<ExplorerModel>(await ExplorerService.GetExplorerById(Id));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(Explorer);
            }
        }

        [HttpPost()]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateExplorer([FromBody] ExplorerModel ExplorerCreate)
        {
            if (ExplorerCreate == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Explorer = mapper.Map<Explorer>(ExplorerCreate);

            if (!await ExplorerService.CreateExplorer(Explorer))
            {
                ModelState.AddModelError("", "Something went wrong while Saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");
        }

        [HttpDelete("Delete/{Id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteExplorer(int Id)
        {
            if (!await ExplorerService.ExplorerExistsByID(Id))
            {
                return NotFound();
            }

            var ExplorerToDelete = await ExplorerService.GetExplorerById(Id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await ExplorerService.DeleteExplorer(ExplorerToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting your Explorer");
                return StatusCode(500, ModelState);

            }
            return NoContent();

        }
    }
}
