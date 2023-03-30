using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MoneyMe.Api.Source.Domain.Features.SubmitApplication
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmitApplicationController : ControllerBase
    {
        private readonly IMediator mediator;

        public SubmitApplicationController(IMediator mediator) => this.mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> SubmitQuote([FromBody] SubmitApplicationParameters model)
        {
            await mediator.Send(new SubmitApplicationCommand(model));

            return Ok();
        }
    }
}
