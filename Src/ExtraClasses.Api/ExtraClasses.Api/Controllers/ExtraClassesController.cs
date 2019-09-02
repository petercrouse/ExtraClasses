using ExtraClasses.Application.ExtraClasses.Commands.CreateExtraClass;
using ExtraClasses.Application.ExtraClasses.Commands.DeleteExtraClass;
using ExtraClasses.Application.ExtraClasses.Commands.UpdateExtraClass;
using ExtraClasses.Application.ExtraClasses.Queries.GetExtraClass;
using ExtraClasses.Application.ExtraClasses.Queries.GetExtraClassList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExtraClasses.Api.Controllers
{
    public class ExtraClassesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ExtraClassListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetExtraClassListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExtraClassViewModel>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetExtraClassQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExtraClassCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody]UpdateExtraClassCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteExtraClassCommand { Id = id });

            return NoContent();
        }
    }
}
