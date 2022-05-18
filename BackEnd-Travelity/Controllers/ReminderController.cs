using AutoMapper;
using BackEnd_Travelity.Domain;
using BackEnd_Travelity.DTO.Reminder_DTOModel;
using BackEnd_Travelity.Services.ReminderService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Travelity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AdminCors")]
    public class ReminderController : Controller
    {
        private readonly IReminderService ReminderService;
        private readonly IMapper mapper;
        public ReminderController(IReminderService _ReminderService, IMapper _mapper)
        {
            ReminderService = _ReminderService;
            mapper = _mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reminder>))]
        public async Task<IActionResult> GetAllRemidners()
        {
            var Reminders = mapper.Map<List<ReminderModel>>(await ReminderService.GetAllReminders());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Reminders);
        }

        [HttpGet("Id/{Id}")]
        [ProducesResponseType(200, Type = typeof(Reminder))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetReminderById(int Id)
        {
            if (!await ReminderService.ReminderExistsByID(Id))
            {
                return NotFound();
            }
            var Reminder = mapper.Map<ReminderModel>(await ReminderService.GetReminderById(Id));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(Reminder);
            }
        }

        [HttpGet("Item/{Item}")]
        [ProducesResponseType(200, Type = typeof(Reminder))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetReminderByItem(string Item)
        {
            if (!await ReminderService.ReminderExistsByItem(Item))
            {
                return NotFound();
            }
            var Reminder = mapper.Map<ReminderModel>(await ReminderService.GetByReminderItem(Item));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(Reminder);
            }
        }

        [HttpPost()]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateReminder([FromBody] ReminderModel ReminderCreate)
        {
            if (ReminderCreate == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Reminder = mapper.Map<Reminder>(ReminderCreate);

            if (!await ReminderService.CreateReminder(Reminder))
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
        public async Task<IActionResult> UpdateReminder(int Id, [FromBody] UpdateReminderModel updateReminder)
        {
            if (updateReminder == null)
            {
                return BadRequest(ModelState);
            }
            if (Id != updateReminder.Id)
            {
                return BadRequest(ModelState);

            }

            if (!await ReminderService.ReminderExistsByID(Id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var Reminder = mapper.Map<Reminder>(updateReminder);

            if (!await ReminderService.UpdateReminder(Reminder))
            {
                ModelState.AddModelError("", "Something went wrong updating your Reminder");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("Delete/{Id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteReminder(int Id)
        {
            if (!await ReminderService.ReminderExistsByID(Id))
            {
                return NotFound();
            }

            var remidnerToDelete = await ReminderService.GetReminderById(Id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await ReminderService.DeleteReminder(remidnerToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting your Reminder");
                return StatusCode(500, ModelState);

            }
            return NoContent();

        }
    }
}
