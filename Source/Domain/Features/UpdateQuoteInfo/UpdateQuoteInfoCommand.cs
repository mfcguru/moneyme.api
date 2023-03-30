using MediatR;
using MoneyMe.Api.Source.Infrastructure.DataProvider;

namespace MoneyMe.Api.Source.Domain.Features.UpdateQuoteInfo
{
    public class UpdateQuoteInfoCommand : IRequest
    {
        private readonly UpdateQuoteInfoParameters parameters; 
        public UpdateQuoteInfoCommand(UpdateQuoteInfoParameters parameters) => this.parameters = parameters;

        public class Handler : IRequestHandler<UpdateQuoteInfoCommand>
        {
            private readonly IDataProvider dataProvider;
            public Handler(IDataProvider dataProvider)
            {
                this.dataProvider = dataProvider;
            }

            public async Task<Unit> Handle(UpdateQuoteInfoCommand request, CancellationToken cancellationToken)
            {
                await dataProvider.UpdateQuote(
                    request.parameters.QuoteId,
                    request.parameters.AmountRequired,
                    request.parameters.Term,
                    request.parameters.ProductType);

                return Unit.Value;  
            }
        }
    }
}
