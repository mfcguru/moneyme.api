using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MoneyMe.Api.Source.Domain.Features.CalculateQuote
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateQuoteController : ControllerBase
    {
        private readonly IMediator mediator;

        public CalculateQuoteController(IMediator mediator) => this.mediator = mediator;

        [HttpGet("{quoteIdentifier}")]
        public async Task<IActionResult> CalculateQuotation(string quoteIdentifier)
        {
            var result = await mediator.Send(new CalculateQuoteCommand(quoteIdentifier));

            return Ok(result);
        }
    }
}
