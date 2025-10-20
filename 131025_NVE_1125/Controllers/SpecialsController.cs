using _131025_NVE_1125.CQRS_Special;
using _131025_NVE_1125.CQRS_Special.GetSpecials;
using _131025_NVE_1125.CQRS_Student.ListStudentsWOutGroup;
using Microsoft.AspNetCore.Mvc;
using MyMediator.Types;

namespace _131025_NVE_1125.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialsController(Mediator mediator) : Controller
    {
        private readonly Mediator mediator = mediator;

        [HttpGet("GetSpecials")]
        public async Task<ActionResult<IEnumerable<SpecialDTO>>> GetStudentsWOutGroup()
        {
            var command = new GetSpecialsCommand();
            return Ok(await mediator.SendAsync(command));
        }

    }
}
