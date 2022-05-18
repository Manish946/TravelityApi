using AutoMapper;
using BackEnd_Travelity.Domain;
using BackEnd_Travelity.DTO.Comment_DTOModel;
using BackEnd_Travelity.Services.CommentService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Travelity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AdminCors")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService CommentService;
        private readonly IMapper mapper;
        public CommentController(ICommentService _CommentService, IMapper _mapper)
        {
            CommentService = _CommentService;
            mapper = _mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Comment>))]
        public async Task<IActionResult> GetAllComments()
        {
            var Comments = mapper.Map<List<CommentModel>>(await CommentService.GetAllComments());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Comments);
        }

        [HttpGet("Id/{Id}")]
        [ProducesResponseType(200, Type = typeof(Comment))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCommentById(int Id)
        {
            if (!await CommentService.CommentExistsByID(Id))
            {
                return NotFound();
            }
            var Comment = mapper.Map<CommentModel>(await CommentService.GetCommentById(Id));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(Comment);
            }
        }

        [HttpPost()]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateComment([FromBody] CommentModel CommentCreate)
        {
            if (CommentCreate == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Comment = mapper.Map<Comment>(CommentCreate);

            if (!await CommentService.CreateComment(Comment))
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
        public async Task<IActionResult> DeleteComment(int Id)
        {
            if (!await CommentService.CommentExistsByID(Id))
            {
                return NotFound();
            }

            var CommentToDelete = await CommentService.GetCommentById(Id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await CommentService.DeleteComment(CommentToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting your Comment");
                return StatusCode(500, ModelState);

            }
            return NoContent();

        }
    }
}
