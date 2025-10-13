using _131025_NVE_1125.CQRS_Array.CommandGetMassiveOfIndexOfZeroFromArray;
using _131025_NVE_1125.CQRS_Array.CommandSignOfFirstElem;
using _131025_NVE_1125.CQRS_Array.CommandSummElementsMultiplesOfK;
using Microsoft.AspNetCore.Mvc;
using MyMediator.Types;

namespace _131025_NVE_1125.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArraysController : Controller
    {
        private readonly Mediator mediator;
        public ArraysController(Mediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("ArrayGetSummOfElementsMultiplesOfK")]
        public async Task<ActionResult<int>> ArrayGetSummOfElementsMultiplesOfKAsync(int k, [FromBody] int[] array)
        {

            var command = new CommandSummElementsMultiplesOfK() { Array = array, Multiplier = k };
            var result = await mediator.SendAsync(command);
            return Ok(result);
        }
        [HttpPost("MassiveOfIndexOfZeroFromArray")]
        public async Task<ActionResult<int>> MassiveOfIndexOfZeroFromArrayAsync([FromBody] int[] array)
        {
            var command = new CommandGetMassiveOfIndexOfZeroFromArray() { Array = array};
            var result = await mediator.SendAsync(command);
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<ActionResult<string>> FirstElemPositiveOrNegativeAsync([FromBody] int[] array)
        {
            var command = new CommandSignOfFirstElem() { Array = array };
            //var result = 
            return Ok(array);
        }
    }
}
