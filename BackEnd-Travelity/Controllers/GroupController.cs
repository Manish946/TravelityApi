using AutoMapper;
using BackEnd_Travelity.Domain;
using BackEnd_Travelity.DTO.Group_DTOModel;
using BackEnd_Travelity.Services.GroupService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Travelity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AdminCors")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService GroupService;
        private readonly IMapper mapper;
        public GroupController(IGroupService _GroupService, IMapper _mapper)
        {
            GroupService = _GroupService;
            mapper = _mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Group>))]
        public async Task<IActionResult> GetAllGroups()
        {
            var Groups = mapper.Map<List<GroupModel>>(await GroupService.GetAllGroups());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Groups);
        }

        [HttpGet("Id/{Id}")]
        [ProducesResponseType(200, Type = typeof(Group))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetGroupById(int Id)
        {
            if (!await GroupService.GroupExistsByID(Id))
            {
                return NotFound();
            }
            var Group = mapper.Map<GroupModel>(await GroupService.GetGroupById(Id));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(Group);
            }
        }

        [HttpGet("Group/{Title}")]
        [ProducesResponseType(200, Type = typeof(Group))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetGroupByName(string Group_Name)
        {
            if (!await GroupService.GroupExistsByName(Group_Name))
            {
                return NotFound();
            }
            var Group = mapper.Map<GroupModel>(await GroupService.GroupExistsByName(Group_Name));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return Ok(Group);
            }
        }

        [HttpPost()]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateGroup([FromBody] GroupModel GroupCreate)
        {
            if (GroupCreate == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Group = mapper.Map<Group>(GroupCreate);

            if (!await GroupService.CreateGroup(Group))
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
        public async Task<IActionResult> UpdateGroup(int Id, [FromBody] UpdateGroupModel updatedGroup)
        {
            if (updatedGroup == null)
            {
                return BadRequest(ModelState);
            }
            if (Id != updatedGroup.Id)
            {
                return BadRequest(ModelState);

            }

            if (!await GroupService.GroupExistsByID(Id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var Group = mapper.Map<Group>(updatedGroup);

            if (!await GroupService.UpdateGroup(Group))
            {
                ModelState.AddModelError("", "Something went wrong updating your Group");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("Delete/{Id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteGroup(int Id)
        {
            if (!await GroupService.GroupExistsByID(Id))
            {
                return NotFound();
            }

            var GroupToDelete = await GroupService.GetGroupById(Id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await GroupService.DeleteGroup(GroupToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting your Group");
                return StatusCode(500, ModelState);

            }
            return NoContent();

        }
    }
}
