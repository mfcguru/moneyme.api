using MediatR;
using MoneyMe.Api.Source.Domain.Enums;
using MoneyMe.Api.Source.Infrastructure.DataProvider;

namespace MoneyMe.Api.Source.Domain.Features.GetQuote
{
    public class GetQuoteCommand : IRequest<GetQuoteResult>
    {
        private readonly string quoteIdentifier;

        public GetQuoteCommand(string quoteIdentifier) => this.quoteIdentifier = quoteIdentifier;

        public class Handler : IRequestHandler<GetQuoteCommand, GetQuoteResult>
        {
            private readonly IDataProvider dataProvider;

            public Handler(IDataProvider dataProvider) => this.dataProvider = dataProvider;

            public async Task<GetQuoteResult> Handle(GetQuoteCommand request, CancellationToken cancellationToken)
            {
                var quote = await dataProvider.FindQuote(request.quoteIdentifier);

                return new GetQuoteResult
                {
                    QuoteId = quote.ID,
                    ProductType = (ProductType?)quote.ProductType,
                    AmountRequired = quote.AmountRequired,
                    DateOfBirth = quote.Customer.DateOfBirth,
                    Email = quote.Customer.Email,
                    FirstName = quote.Customer.FirstName,
                    LastName = quote.Customer.LastName,
                    Mobile = quote.Customer.Mobile,
                    Term = quote.Term,
                    Title = quote.Customer.Title
                };
            }
        }
    }
}
