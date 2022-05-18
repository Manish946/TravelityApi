using AutoMapper;
using BackEnd_Travelity.Domain;
using BackEnd_Travelity.DTO.Place_DTOModel;
using BackEnd_Travelity.Services.PlaceService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Travelity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AdminCors")]
    public class PlaceController : Controller
    {
        private readonly IPlaceService PlaceService;
        private readonly IMapper mapper;
        public PlaceController(IPlaceService _PlaceService, IMapper _mapper)
        {
            PlaceService = _PlaceService;
            mapper = _mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Place>))]
        public async Task<IActionResult> GetAllPlaces()
        {
            var Places = mapper.Map<List<PlaceModel>>(await PlaceService.GetAllPlaces());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Places);
        }

        [HttpGet("Id/{Id}")]
        [ProducesResponseType(200, Type = typeof(Place))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetPlaceById(int Id)
        {
            if (!await PlaceService.PlaceExistsByID(Id))
            {
                return NotFound();
            }
            var Place = mapper.Map<PlaceModel>(await PlaceService.GetPlaceById(Id));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(Place);
            }
        }

        [HttpGet("Place/{Country}")]
        [ProducesResponseType(200, Type = typeof(Place))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetPlaceByCountry(string Country)
        {
            if (!await PlaceService.PlaceExistsByCountry(Country))
            {
                return NotFound();
            }
            var Place = mapper.Map<PlaceModel>(await PlaceService.GetByPlaceCountry(Country));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(Place);
            }
        }
    }
}
