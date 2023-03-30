using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MoneyMe.Api.Source.Domain.Features.RequestQuote
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestQuoteController : ControllerBase
    {
        private readonly IMediator mediator;

        public RequestQuoteController(IMediator mediator) => this.mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> RequestQuotation(RequestQuoteParameters model)
        {
            var result = await mediator.Send(new RequestQuoteCommand(model));

            return Ok(result);
        }
    }
}
