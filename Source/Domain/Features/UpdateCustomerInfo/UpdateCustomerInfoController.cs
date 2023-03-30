using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MoneyMe.Api.Source.Domain.Features.UpdateCustomerInfo
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateCustomerInfoController : ControllerBase
    {
        private readonly IMediator mediator;

        public UpdateCustomerInfoController(IMediator mediator) => this.mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> UpdateCustomerInfo([FromBody] UpdateCustomerInfoParameters parameters)
        {
            await mediator.Send(new UpdateCustomerInfoCommand(parameters));

            return Ok();
        }
    }
}
