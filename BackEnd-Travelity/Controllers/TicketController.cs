using AutoMapper;
using BackEnd_Travelity.Domain;
using BackEnd_Travelity.DTO.Ticket_DTOModel;
using BackEnd_Travelity.Services.TicketService;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Travelity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService TicketService;
        private readonly IMapper mapper;
        public TicketController(ITicketService _TicketService, IMapper _mapper)
        {
            TicketService = _TicketService;
            mapper = _mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Ticket>))]
        public async Task<IActionResult> GetAllTickets()
        {
            var Tickets = mapper.Map<List<TicketModel>>(await TicketService.GetAllTickets());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Tickets);
        }
        [HttpGet("Id/{Id}")]
        [ProducesResponseType(200, Type = typeof(Ticket))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTicketById(int Id)
        {
            if (!await TicketService.TicketExistsByID(Id))
            {
                return NotFound();
            }
            var Ticket = mapper.Map<TicketModel>(await TicketService.GetTicketById(Id));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(Ticket);
            }
        }
        [HttpGet("Ticket/{Title}")]
        [ProducesResponseType(200, Type = typeof(Ticket))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTicketByTitle(string Title)
        {
            if (!await TicketService.TicketExistsByTitle(Title))
            {
                return NotFound();
            }
            var Ticket = mapper.Map<TicketModel>(await TicketService.GetByTicketTitle(Title));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(Ticket);
            }
        }
        [HttpPost()]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateTicket([FromBody] TicketModel TicketCreate)
        {
            if (TicketCreate == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Ticket = mapper.Map<Ticket>(TicketCreate);

            if (!await TicketService.CreateTicket(Ticket))
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
        public async Task<IActionResult> UpdateTicket(int Id, [FromBody] UpdateTicketModel updatedTicket)
        {
            if (updatedTicket == null)
            {
                return BadRequest(ModelState);
            }
            if (Id != updatedTicket.Id)
            {
                return BadRequest(ModelState);

            }

            if (!await TicketService.TicketExistsByID(Id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var Ticket = mapper.Map<Ticket>(updatedTicket);

            if (!await TicketService.UpdateTicket(Ticket))
            {
                ModelState.AddModelError("", "Something went wrong updating your Ticket");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("Delete/{Id}")]
        // Created Response Type
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        // For id and user name parameter add [FromQuery]
        public async Task<IActionResult> DeleteTicket(int Id)
        {
            if (!await TicketService.TicketExistsByID(Id))
            {
                return NotFound();
            }

            var TicketToDelete = await TicketService.GetTicketById(Id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await TicketService.DeleteTicket(TicketToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting your Ticket");
                return StatusCode(500, ModelState);

            }
            return NoContent();

        }
    }
}
