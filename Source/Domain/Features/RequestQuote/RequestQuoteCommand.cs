using MediatR;
using MoneyMe.Api.Source.Domain.Enums;
using MoneyMe.Api.Source.Infrastructure.DataProvider;
using MoneyMe.Api.Source.Infrastructure.RedirectUrlGenerator;

namespace MoneyMe.Api.Source.Domain.Features.RequestQuote
{
    public class RequestQuoteCommand : IRequest<RequestQuoteResult>
    {
        private readonly RequestQuoteParameters parameters;
        public RequestQuoteCommand(RequestQuoteParameters parameters) => this.parameters = parameters;

        public class Handler : IRequestHandler<RequestQuoteCommand, RequestQuoteResult>
        {
            private readonly IDataProvider dataProvider;
            private readonly IRedirectUrlGenerator urlGenerator;
            public Handler(IDataProvider dataProvider, IRedirectUrlGenerator urlGenerator)
            {
                this.dataProvider = dataProvider;
                this.urlGenerator = urlGenerator;
            }

            public async Task<RequestQuoteResult> Handle(RequestQuoteCommand request, CancellationToken cancellationToken)
            {
                var quote = await dataProvider.FindQuote(
                    request.parameters.FirstName, 
                    request.parameters.LastName, 
                    request.parameters.DateOfBirth);

                if (quote != null)
                {
                    await dataProvider.UpdateQuote(
                        quote.ID,
                        request.parameters.FirstName,
                        request.parameters.LastName,
                        request.parameters.DateOfBirth,
                        (TitleType)request.parameters.Title,
                        request.parameters.Mobile,
                        request.parameters.Email,
                        request.parameters.AmountRequired,
                        request.parameters.Term,
                        null);

                    return new RequestQuoteResult
                    {
                        RedirectUrl = urlGenerator.GenerateUrlFromId(quote.ID)
                    };
                }
                else
                {
                    int quoteId = await dataProvider.SaveQuote(
                        request.parameters.FirstName, 
                        request.parameters.LastName, 
                        request.parameters.DateOfBirth,
                        (TitleType)request.parameters.Title, 
                        request.parameters.Mobile, 
                        request.parameters.Email, 
                        request.parameters.AmountRequired, 
                        request.parameters.Term);

                    return new RequestQuoteResult
                    {
                        RedirectUrl = urlGenerator.GenerateUrlFromId(quoteId)
                    };
                }
            }
        }
    }
}
