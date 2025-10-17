using _131025_NVE_1125.CQRS_Group;
using _131025_NVE_1125.CQRS_Group.AddGroupCommand;
using _131025_NVE_1125.CQRS_Group.GetGroupsCommand;
using _131025_NVE_1125.CQRS_Group.GetGroupsWOutStudentsCommand;
using Microsoft.AspNetCore.Mvc;
using MyMediator.Types;

namespace _131025_NVE_1125.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController(Mediator mediator) : Controller
    {
        private readonly Mediator mediator = mediator;

        [HttpGet("GetGroupsWOutStudents")]
        public async Task<ActionResult<IEnumerable<GroupDTO>>> GetGroupsWOutStudents()
        {
            var command = new GetGroupsWOutStudentsCommand();
            return Ok(await mediator.SendAsync(command));
        }

        [HttpGet("GetGroups")]
        public async Task<ActionResult<IEnumerable<GroupDTO>>> GetGroups()
        {
            var command = new GetGroupsCommand();
            return Ok(await mediator.SendAsync(command));
        }

        [HttpPost("AddGroup")]
        public async Task<ActionResult> AddGroup(GroupDTO group)
        {
            var command = new AddGroupCommand() { Title = group.Title, IdSpecial = group.IdSpecial};
            await mediator.SendAsync(command);
            return Created();
        }

    }
}
