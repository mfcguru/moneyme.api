using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MoneyMe.Api.Source.Domain.Features.PreCalculateQuote
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrecalculateQuoteController : ControllerBase
    {
        private readonly IMediator mediator;

        public PrecalculateQuoteController(IMediator mediator) => this.mediator = mediator;

        [HttpPost("{quoteIdentifier}")]
        public async Task<IActionResult> PrecalculateQuote(string quoteIdentifier, [FromBody] PreCalculateQuoteParameters parameters)
        {
            var result = await mediator.Send(new PreCalculateQuoteCommand(quoteIdentifier, parameters));

            return Ok(result);
        }
    }
}
