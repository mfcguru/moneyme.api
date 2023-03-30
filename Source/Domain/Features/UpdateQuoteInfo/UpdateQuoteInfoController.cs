using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MoneyMe.Api.Source.Domain.Features.UpdateQuoteInfo
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateQuoteInfoController : ControllerBase
    {
        private readonly IMediator mediator;

        public UpdateQuoteInfoController(IMediator mediator) => this.mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> UpdateQuoteInfo([FromBody] UpdateQuoteInfoParameters parameters)
        {
            await mediator.Send(new UpdateQuoteInfoCommand(parameters));

            return Ok();
        }
    }
}
