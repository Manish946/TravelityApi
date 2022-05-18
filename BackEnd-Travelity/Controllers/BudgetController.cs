using AutoMapper;
using BackEnd_Travelity.Domain;
using BackEnd_Travelity.DTO.Budget_DTOModel;
using BackEnd_Travelity.Services.BudgetService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Travelity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AdminCors")]
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetService BudgetService;
        private readonly IMapper mapper;
        public BudgetController(IBudgetService _BudgetService, IMapper _mapper)
        {
            BudgetService = _BudgetService;
            mapper = _mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Budget>))]
        public async Task<IActionResult> GetAllBudgets()
        {
            var Budgets = mapper.Map<List<BudgetModel>>(await BudgetService.GetAllBudgets());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Budgets);
        }

        [HttpGet("Id/{Id}")]
        [ProducesResponseType(200, Type = typeof(Budget))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetBudgetById(int Id)
        {
            if (!await BudgetService.BudgetExistsByID(Id))
            {
                return NotFound();
            }
            var Budget = mapper.Map<BudgetModel>(await BudgetService.GetBudgetById(Id));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(Budget);
            }
        }

        [HttpPost()]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateBudget([FromBody] BudgetModel BudgetCreate)
        {
            if (BudgetCreate == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Budget = mapper.Map<Budget>(BudgetCreate);

            if (!await BudgetService.CreateBudget(Budget))
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
        public async Task<IActionResult> UpdateBudget(int Id, [FromBody] UpdateBudgetModel updatedBudget)
        {
            if (updatedBudget == null)
            {
                return BadRequest(ModelState);
            }
            if (Id != updatedBudget.Id)
            {
                return BadRequest(ModelState);

            }

            if (!await BudgetService.BudgetExistsByID(Id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var Budget = mapper.Map<Budget>(updatedBudget);

            if (!await BudgetService.UpdateBudget(Budget))
            {
                ModelState.AddModelError("", "Something went wrong updating your Budget");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("Delete/{Id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteBudget(int Id)
        {
            if (!await BudgetService.BudgetExistsByID(Id))
            {
                return NotFound();
            }

            var BudgetToDelete = await BudgetService.GetBudgetById(Id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await BudgetService.DeleteBudget(BudgetToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting your Budget");
                return StatusCode(500, ModelState);

            }
            return NoContent();

        }
    }
}
