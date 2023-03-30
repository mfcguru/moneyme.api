using MediatR;
using MoneyMe.Api.Source.Domain.BusinessRules;
using MoneyMe.Api.Source.Domain.Enums;
using MoneyMe.Api.Source.Infrastructure.DataProvider;
using MoneyMe.Api.Source.Infrastructure.RedirectUrlGenerator;

namespace MoneyMe.Api.Source.Domain.Features.PreCalculateQuote
{
    public class PreCalculateQuoteCommand : IRequest
    {
        private readonly string quoteIdentifier;
        private readonly PreCalculateQuoteParameters parameters;
        public PreCalculateQuoteCommand(string quoteIdentifier, PreCalculateQuoteParameters parameters)
        {
            this.quoteIdentifier = quoteIdentifier;
            this.parameters = parameters;
        }

        public class Handler : IRequestHandler<PreCalculateQuoteCommand>
        {
            private readonly IDataProvider dataProvider;
            private readonly IRedirectUrlGenerator redirectUrlGenerator;    

            public Handler(IDataProvider dataProvider, IRedirectUrlGenerator redirectUrlGenerator)
            {
                this.dataProvider = dataProvider;
                this.redirectUrlGenerator = redirectUrlGenerator;
            }

            public async Task<Unit> Handle(PreCalculateQuoteCommand request, CancellationToken cancellationToken)
            {
                if (request.parameters.ProductType == ProductType.ProductB && request.parameters.Term < 6)
                {
                    throw new ProductBSixMonthsMinTermException();
                }

                int quoteId = redirectUrlGenerator.GenerateIdFromString(request.quoteIdentifier);

                await dataProvider.UpdateQuote(
                    quoteId, 
                    request.parameters.FirstName,
                    request.parameters.LastName,
                    request.parameters.DateOfBirth,
                    (TitleType)request.parameters.Title,
                    request.parameters.Mobile,
                    request.parameters.Email,
                    request.parameters.AmountRequired,
                    request.parameters.Term,
                    request.parameters.ProductType);

                return Unit.Value;
            }
        }
    }
}
