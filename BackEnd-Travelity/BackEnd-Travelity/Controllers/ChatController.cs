using AutoMapper;
using BackEnd_Travelity.Domain;
using BackEnd_Travelity.DTO.Chat_DTOModel;
using BackEnd_Travelity.Services.ChatService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Travelity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AdminCors")]
    public class ChatController : ControllerBase
    {
        private readonly IChatService ChatService;
        private readonly IMapper mapper;
        public ChatController(IChatService _ChatService, IMapper _mapper)
        {
            ChatService = _ChatService;
            mapper = _mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Chat>))]
        public async Task<IActionResult> GetAllChats()
        {
            var Chats = mapper.Map<List<ChatModel>>(await ChatService.GetAllChats());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Chats);
        }

        [HttpGet("Id/{Id}")]
        [ProducesResponseType(200, Type = typeof(Chat))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetChatById(int Id)
        {
            if (!await ChatService.ChatExistsByID(Id))
            {
                return NotFound();
            }
            var Chat = mapper.Map<ChatModel>(await ChatService.GetChatById(Id));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(Chat);
            }
        }

        [HttpPost()]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateChat([FromBody] ChatModel ChatCreate)
        {
            if (ChatCreate == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Chat = mapper.Map<Chat>(ChatCreate);

            if (!await ChatService.CreateChat(Chat))
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
        public async Task<IActionResult> DeleteChat(int Id)
        {
            if (!await ChatService.ChatExistsByID(Id))
            {
                return NotFound();
            }

            var ChatToDelete = await ChatService.GetChatById(Id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await ChatService.DeleteChat(ChatToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting your Chat");
                return StatusCode(500, ModelState);

            }
            return NoContent();

        }
    }
}
