using MediatR;
using MoneyMe.Api.Source.Infrastructure.DataProvider;

namespace MoneyMe.Api.Source.Domain.Features.UpdateCustomerInfo
{
    public class UpdateCustomerInfoCommand : IRequest
    {
        private readonly UpdateCustomerInfoParameters parameters;
        public UpdateCustomerInfoCommand(UpdateCustomerInfoParameters parameters) => this.parameters = parameters;

        public class Handler : IRequestHandler<UpdateCustomerInfoCommand>
        {
            private readonly IDataProvider dataProvider;

            public Handler(IDataProvider dataProvider)
            {
                this.dataProvider = dataProvider;
            }

            public async Task<Unit> Handle(UpdateCustomerInfoCommand request, CancellationToken cancellationToken)
            {
                await dataProvider.UpdateCustomer(
                    request.parameters.CustomerId,
                    request.parameters.FirstName,
                    request.parameters.LastName,
                    request.parameters.DateOfBirth,
                    request.parameters.Title,
                    request.parameters.Mobile,
                    request.parameters.Email);

                return Unit.Value;
            }
        }
    }
}
