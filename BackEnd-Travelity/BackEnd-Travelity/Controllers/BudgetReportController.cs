using AutoMapper;
using BackEnd_Travelity.Domain;
using BackEnd_Travelity.DTO.BudgetReport_DTOModel;
using BackEnd_Travelity.Services.BudgetReportService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace BackEnd_Travelity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AdminCors")]
    public class BudgetReportController : ControllerBase
    {
        private readonly IBudgetReportService BudgetReportService;
        private readonly IMapper mapper;
        public BudgetReportController(IBudgetReportService _BudgetReportService, IMapper _mapper)
        {
            BudgetReportService = _BudgetReportService;
            mapper = _mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BudgetReport>))]
        public async Task<IActionResult> GetAllBudgetReports()
        {
            var BudgetReports = mapper.Map<List<BudgetReportModel>>(await BudgetReportService.GetAllBudgetReports());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(BudgetReports);
        }

        [HttpGet("Id/{Id}")]
        [ProducesResponseType(200, Type = typeof(BudgetReport))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetBudgetReportById(int Id)
        {
            if (!await BudgetReportService.BudgetReportExistsByID(Id))
            {
                return NotFound();
            }
            var BudgetReport = mapper.Map<BudgetReportModel>(await BudgetReportService.GetBudgetReportById(Id));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(BudgetReport);
            }
        }

        [HttpPost()]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateBudgetReport([FromBody] BudgetReportModel BudgetReportCreate)
        {
            if (BudgetReportCreate == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var BudgetReport = mapper.Map<BudgetReport>(BudgetReportCreate);

            if (!await BudgetReportService.CreateBudgetReport(BudgetReport))
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
        public async Task<IActionResult> UpdateBudgetReport(int Id, [FromBody] UpdateBudgetReportModel updatedBudgetReport)
        {
            if (updatedBudgetReport == null)
            {
                return BadRequest(ModelState);
            }
            if (Id != updatedBudgetReport.Id)
            {
                return BadRequest(ModelState);

            }

            if (!await BudgetReportService.BudgetReportExistsByID(Id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var BudgetReport = mapper.Map<BudgetReport>(updatedBudgetReport);

            if (!await BudgetReportService.UpdateBudgetReport(BudgetReport))
            {
                ModelState.AddModelError("", "Something went wrong updating your BudgetReport");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("Delete/{Id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteBudgetReport(int Id)
        {
            if (!await BudgetReportService.BudgetReportExistsByID(Id))
            {
                return NotFound();
            }

            var BudgetReportToDelete = await BudgetReportService.GetBudgetReportById(Id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await BudgetReportService.DeleteBudgetReport(BudgetReportToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting your BudgetReport");
                return StatusCode(500, ModelState);

            }
            return NoContent();

        }
    }
}
