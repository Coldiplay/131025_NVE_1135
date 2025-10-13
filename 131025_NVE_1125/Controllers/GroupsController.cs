using _131025_NVE_1125.CQRS_Group;
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

        [HttpPost("GetGroupsWOutStudents")]
        public async Task<ActionResult<IEnumerable<GroupDTO>>> GetGroupsWOutStudents()
        {
            var command = new GetGroupsWOutStudentsCommand();
            return Ok(mediator.SendAsync(command));
        }

    }
}
