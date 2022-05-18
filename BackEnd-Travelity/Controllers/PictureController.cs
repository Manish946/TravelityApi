using AutoMapper;
using BackEnd_Travelity.Domain;
using BackEnd_Travelity.DTO.Picture_DTOModel;
using BackEnd_Travelity.Services.PictureService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Travelity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AdminCors")]
    public class PictureController : ControllerBase
    {
        private readonly IPictureService PictureService;
        private readonly IMapper mapper;
        public PictureController(IPictureService _PictureService, IMapper _mapper)
        {
            PictureService = _PictureService;
            mapper = _mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Picture>))]
        public async Task<IActionResult> GetAllPictures()
        {
            var Picture = mapper.Map<List<PictureModel>>(await PictureService.GetAllPictures());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Picture);
        }

        [HttpGet("Id/{Id}")]
        [ProducesResponseType(200, Type = typeof(Picture))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetPictureById(int Id)
        {
            if (!await PictureService.PictureExistsByID(Id))
            {
                return NotFound();
            }
            var Picture = mapper.Map<PictureModel>(await PictureService.GetPictureById(Id));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(Picture);
            }
        }

        [HttpPost()]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreatePicture([FromBody] PictureModel PictureCreate)
        {
            if (PictureCreate == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Picture = mapper.Map<Picture>(PictureCreate);

            if (!await PictureService.CreatePicture(Picture))
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
        public async Task<IActionResult> DeletePicture(int Id)
        {
            if (!await PictureService.PictureExistsByID(Id))
            {
                return NotFound();
            }

            var PictureToDelete = await PictureService.GetPictureById(Id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await PictureService.DeletePicture(PictureToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting your Picture");
                return StatusCode(500, ModelState);

            }
            return NoContent();

        }
    }
}
