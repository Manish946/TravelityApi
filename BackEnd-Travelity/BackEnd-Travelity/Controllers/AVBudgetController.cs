using AutoMapper;
using BackEnd_Travelity.Domain;
using BackEnd_Travelity.DTO.AVBudget_DTOModel;
using BackEnd_Travelity.Services.AVBudgetService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Travelity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AdminCors")]
    public class AVBudgetController : ControllerBase
    {
        private readonly IAVBudgetService AVBudgetService;
        private readonly IMapper mapper;
        public AVBudgetController(IAVBudgetService _AVBudgetService, IMapper _mapper)
        {
            AVBudgetService = _AVBudgetService;
            mapper = _mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AVBudget>))]
        public async Task<IActionResult> GetAllAVBudgets()
        {
            var AVBudgets = mapper.Map<List<AvBudgetModel>>(await AVBudgetService.GetAllAVBudgets());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(AVBudgets);
        }

        [HttpGet("Id/{Id}")]
        [ProducesResponseType(200, Type = typeof(AVBudget))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAVBudgetById(int Id)
        {
            if (!await AVBudgetService.AVBudgetExistsByID(Id))
            {
                return NotFound();
            }
            var AVBudget = mapper.Map<AvBudgetModel>(await AVBudgetService.GetAVBudgetById(Id));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(AVBudget);
            }
        }

        [HttpPost()]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateAVBudget([FromBody] AvBudgetModel AVBudgetCreate)
        {
            if (AVBudgetCreate == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var AVBudget = mapper.Map<AVBudget>(AVBudgetCreate);

            if (!await AVBudgetService.CreateAVBudget(AVBudget))
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
        public async Task<IActionResult> UpdateAVBudget(int Id, [FromBody] UpdateAVBudgetModel updatedAVBudget)
        {
            if (updatedAVBudget == null)
            {
                return BadRequest(ModelState);
            }
            if (Id != updatedAVBudget.Id)
            {
                return BadRequest(ModelState);

            }

            if (!await AVBudgetService.AVBudgetExistsByID(Id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var AVBudget = mapper.Map<AVBudget>(updatedAVBudget);

            if (!await AVBudgetService.UpdateAVBudget(AVBudget))
            {
                ModelState.AddModelError("", "Something went wrong updating your AVBudget");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("Delete/{Id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteAVBudget(int Id)
        {
            if (!await AVBudgetService.AVBudgetExistsByID(Id))
            {
                return NotFound();
            }

            var AVBudgetToDelete = await AVBudgetService.GetAVBudgetById(Id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await AVBudgetService.DeleteAVBudget(AVBudgetToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting your AVBudget");
                return StatusCode(500, ModelState);

            }
            return NoContent();

        }
    }
}
