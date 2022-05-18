using AutoMapper;
using BackEnd_Travelity.Domain;
using BackEnd_Travelity.DTO.Admin_DTOModel;
using BackEnd_Travelity.Services.AdminService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Travelity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AdminCors")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService AdminService;
        private readonly IMapper mapper;
        public AdminController(IAdminService _AdminService, IMapper _mapper)
        {
            AdminService = _AdminService;
            mapper = _mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Admin>))]
        public async Task<IActionResult> GetAllAdmins()
        {
            var Admins = mapper.Map<List<AdminModel>>(await AdminService.GetAllAdmins());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Admins);
        }

        [HttpGet("Id/{Id}")]
        [ProducesResponseType(200, Type = typeof(Admin))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAdminById(int Id)
        {
            if (!await AdminService.AdminExistsByID(Id))
            {
                return NotFound();
            }
            var Admin = mapper.Map<AdminModel>(await AdminService.GetAdminById(Id));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(Admin);
            }
        }

        [HttpPost()]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateAdmin([FromBody] AdminModel AdminCreate)
        {
            if (AdminCreate == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Admin = mapper.Map<Admin>(AdminCreate);

            if (!await AdminService.CreateAdmin(Admin))
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
        public async Task<IActionResult> UpdateAdmin(int Id, [FromBody] UpdateAdminModel updatedAdmin)
        {
            if (updatedAdmin == null)
            {
                return BadRequest(ModelState);
            }
            if (Id != updatedAdmin.Id)
            {
                return BadRequest(ModelState);

            }

            if (!await AdminService.AdminExistsByID(Id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var Admin = mapper.Map<Admin>(updatedAdmin);

            if (!await AdminService.UpdateAdmin(Admin))
            {
                ModelState.AddModelError("", "Something went wrong updating your Admin");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("Delete/{Id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteAdmin(int Id)
        {
            if (!await AdminService.AdminExistsByID(Id))
            {
                return NotFound();
            }

            var AdminToDelete = await AdminService.GetAdminById(Id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await AdminService.DeleteAdmin(AdminToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting your Admin");
                return StatusCode(500, ModelState);

            }
            return NoContent();

        }
    }
}
