using _131025_NVE_1125.CQRS_Student;
using _131025_NVE_1125.CQRS_Student.FindRepeatedStudents;
using _131025_NVE_1125.CQRS_Student.GetGendersNumsByGroupId;
using _131025_NVE_1125.CQRS_Student.ListStudentByGroupId;
using _131025_NVE_1125.CQRS_Student.ListStudentsWOutGroup;
using _131025_NVE_1125.CQRS_Student.StudentMoveGroup;
using Microsoft.AspNetCore.Mvc;
using MyMediator.Types;

namespace _131025_NVE_1125.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController(Mediator mediator) : Controller
    {
        private readonly Mediator mediator = mediator;

        [HttpPost("GetStudentsByGroupIndex")]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudentsByGroupIndex(int idGroup)
        {
            var command = new ListStudentByGroupIdCommand() { GroupId = idGroup };
            return Ok(await mediator.SendAsync(command));
        }

        [HttpPost("GetGendersNumsByGroupId")]
        public async Task<ActionResult<GendersInfo>> GetGendersNumsByGroupId(int groupId)
        {
            var command = new GetGendersNumsByGroupIdCommand() { GroupId = groupId };
            return Ok(await mediator.SendAsync(command));
        }

        [HttpPost("GetStudentsWOutGroup")]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudentsWOutGroup()
        {
            var command = new GetStudentsWOutGroupCommand();
            return Ok(await mediator.SendAsync(command));
        }

        [HttpPost("MoveStudentGroup")]
        public async Task<ActionResult> MoveStudentGroup(int idStudent, int? idGroup)
        {
            var command = new StudentMoveGroupCommand() { StudentId = idStudent, GroupId = idGroup };
            await mediator.SendAsync(command);
            return Ok();
        }

        [HttpPost("FindRepeatedStudents")]
        public async Task<ActionResult<IEnumerable<IEnumerable<StudentDTO>>>> FindRepeatedStudents()
        {
            var command = new FindRepeatedStudentsCommand();
            return Ok(await mediator.SendAsync(command));
        }

    }
}
