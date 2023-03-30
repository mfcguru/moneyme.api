using MediatR;
using Microsoft.Extensions.Options;
using MoneyMe.Api.Source.Domain.Enums;
using MoneyMe.Api.Source.Infrastructure.DataProvider;
using MoneyMe.Api.Source.Infrastructure.QuoteCalculator;

namespace MoneyMe.Api.Source.Domain.Features.CalculateQuote
{
    public class CalculateQuoteCommand : IRequest<CalculateQuoteResult>
    {
        private readonly string quoteIdentifier;
        public CalculateQuoteCommand(string quoteIdentifier) => this.quoteIdentifier = quoteIdentifier;

        public class Handler : IRequestHandler<CalculateQuoteCommand, CalculateQuoteResult>
        {
            private readonly IDataProvider dataProvider;
            private readonly IOptions<AppSettings> appSettings;
            private readonly QuoteCalculatorFactory factory;
            public Handler(
                IDataProvider dataProvider, 
                IOptions<AppSettings> appSettings, 
                QuoteCalculatorFactory factory)
            {
                this.dataProvider = dataProvider;
                this.appSettings = appSettings;
                this.factory = factory;
            }

            public async Task<CalculateQuoteResult> Handle(CalculateQuoteCommand request, CancellationToken cancellationToken)
            {
                var quote = await dataProvider.FindQuote(request.quoteIdentifier);
                var calculator = factory.CreateInstance((ProductType)quote.ProductType);
                var result = calculator.Calculate(
                    quote.Term, 
                    appSettings.Value.YearlyInterestRate,
                    quote.AmountRequired,
                    appSettings.Value.EstablishmentFee);
                
                return new CalculateQuoteResult
                {
                    CustomerInfo = new CalculateQuoteResult.CustomerInfoModel
                    {
                        CustomerId = quote.CustomerID,
                        Title = quote.Customer.Title,
                        Email = quote.Customer.Email,
                        FirstName = quote.Customer.FirstName,
                        LastName = quote.Customer.LastName,
                        Mobile = quote.Customer.Mobile,
                        DateOfBirth = quote.Customer.DateOfBirth
                    },
                    QuoteInfo = new CalculateQuoteResult.QuoteInfoModel
                    {
                        FinanceAmount = quote.AmountRequired,
                        EstablishmentFee = appSettings.Value.EstablishmentFee,
                        Interest = Math.Round(result.Pmt, 2),
                        TotalAmount = Math.Round(result.TotalAmount, 2),
                        Repayments = Math.Round(result.Repayments, 2)
                    },
                    Variables = new CalculateQuoteResult.VariablesModel
                    {
                        QuoteId = quote.ID,
                        ProductType = quote.ProductType.Value,
                        Term = quote.Term
                    }
                };
            }
        }
    }
}
