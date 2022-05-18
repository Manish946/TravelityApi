using AutoMapper;
using BackEnd_Travelity.Domain;
using BackEnd_Travelity.DTO.Permission_DTOModel;
using BackEnd_Travelity.Services.PermissionService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Travelity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AdminCors")]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService PermissionService;
        private readonly IMapper mapper;
        public PermissionController(IPermissionService _PermissionService, IMapper _mapper)
        {
            PermissionService = _PermissionService;
            mapper = _mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Permission>))]
        public async Task<IActionResult> GetAllPermissions()
        {
            var Permissions = mapper.Map<List<PermissionModel>>(await PermissionService.GetAllPermissions());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Permissions);
        }

        [HttpGet("Id/{Id}")]
        [ProducesResponseType(200, Type = typeof(Permission))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetPermissionById(int Id)
        {
            if (!await PermissionService.PermissionExistsByID(Id))
            {
                return NotFound();
            }
            var Permission = mapper.Map<PermissionModel>(await PermissionService.GetPermissionById(Id));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(Permission);
            }
        }

        [HttpPost()]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreatePermission([FromBody] PermissionModel PermissionCreate)
        {
            if (PermissionCreate == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Permission = mapper.Map<Permission>(PermissionCreate);

            if (!await PermissionService.CreatePermission(Permission))
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
        public async Task<IActionResult> UpdatePermission(int Id, [FromBody] UpdatePermissionModel updatedPermission)
        {
            if (updatedPermission == null)
            {
                return BadRequest(ModelState);
            }
            if (Id != updatedPermission.Id)
            {
                return BadRequest(ModelState);

            }

            if (!await PermissionService.PermissionExistsByID(Id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var Permission = mapper.Map<Permission>(updatedPermission);

            if (!await PermissionService.UpdatePermission(Permission))
            {
                ModelState.AddModelError("", "Something went wrong updating your Permission");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("Delete/{Id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeletePermission(int Id)
        {
            if (!await PermissionService.PermissionExistsByID(Id))
            {
                return NotFound();
            }

            var PermissionToDelete = await PermissionService.GetPermissionById(Id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await PermissionService.DeletePermission(PermissionToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting your Permission");
                return StatusCode(500, ModelState);

            }
            return NoContent();

        }
    }
}
