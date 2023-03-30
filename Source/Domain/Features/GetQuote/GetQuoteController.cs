using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoneyMe.Api.Source.Domain.BusinessRules;

namespace MoneyMe.Api.Source.Domain.Features.GetQuote
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetQuoteController : ControllerBase
    {
        private readonly IMediator mediator;

        public GetQuoteController(IMediator mediator) => this.mediator = mediator;

        [HttpGet("{quoteIdentifier}")]
        public async Task<IActionResult> GetQuote(string quoteIdentifier)
        {
            throw new BlockedMobileNoException();

            var result = await mediator.Send(new GetQuoteCommand(quoteIdentifier));

            return Ok(result);
        }
    }
}
