using Application.Gates.Commands.PublishAddGateAccessEvent;
using Application.Gates.Queries.GetSensorResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GatesController(IMediator mediator) : ControllerBase
    {
        [HttpGet(Name = "GetSensorResults")]
        public async Task<IActionResult> GetAsync([FromQuery] GetSensorResultsQuery query, CancellationToken cancellationToken = default)
        {
            var sensorResults = await mediator.Send(query, cancellationToken);
            return Ok(sensorResults);
        }

        [HttpPost(Name = "PublishAddGateAccessEvent")]
        public async Task<IActionResult> PostAsync([FromBody] PublishAddGateAccessEventCommand command, CancellationToken cancellationToken = default)
        {
            await mediator.Send(command, cancellationToken);
            return Accepted();
        }
    }
}
