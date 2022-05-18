using AutoMapper;
using BackEnd_Travelity.Domain;
using BackEnd_Travelity.DTO.Coupon_DTOModel;
using BackEnd_Travelity.Services.CouponService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Travelity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AdminCors")]
    public class CouponController : ControllerBase
    {
        private readonly ICouponService CouponService;
        private readonly IMapper mapper;
        public CouponController(ICouponService _CouponService, IMapper _mapper)
        {
            CouponService = _CouponService;
            mapper = _mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Coupon>))]
        public async Task<IActionResult> GetAllCoupons()
        {
            var Coupons = mapper.Map<List<CouponModel>>(await CouponService.GetAllCoupons());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Coupons);
        }

        [HttpGet("Id/{Id}")]
        [ProducesResponseType(200, Type = typeof(Coupon))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCouponById(int Id)
        {
            if (!await CouponService.CouponExistsByID(Id))
            {
                return NotFound();
            }
            var Coupon = mapper.Map<CouponModel>(await CouponService.GetCouponById(Id));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(Coupon);
            }
        }

        [HttpPost()]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateCoupon([FromBody] CouponModel CouponCreate)
        {
            if (CouponCreate == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Coupon = mapper.Map<Coupon>(CouponCreate);

            if (!await CouponService.CreateCoupon(Coupon))
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
        public async Task<IActionResult> UpdateCoupon(int Id, [FromBody] UpdateCouponModel updatedCoupon)
        {
            if (updatedCoupon == null)
            {
                return BadRequest(ModelState);
            }
            if (Id != updatedCoupon.Id)
            {
                return BadRequest(ModelState);

            }

            if (!await CouponService.CouponExistsByID(Id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var Coupon = mapper.Map<Coupon>(updatedCoupon);

            if (!await CouponService.UpdateCoupon(Coupon))
            {
                ModelState.AddModelError("", "Something went wrong updating your Coupon");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("Delete/{Id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteCoupon(int Id)
        {
            if (!await CouponService.CouponExistsByID(Id))
            {
                return NotFound();
            }

            var CouponToDelete = await CouponService.GetCouponById(Id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await CouponService.DeleteCoupon(CouponToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting your Coupon");
                return StatusCode(500, ModelState);

            }
            return NoContent();

        }
    }
}
