using MoneyMe.Api.Source.Domain.BaseModels;
using MoneyMe.Api.Source.Domain.Enums;

namespace MoneyMe.Api.Source.Domain.Features.GetQuote
{
    public class GetQuoteResult : QuoteModel
    {
        public ProductType? ProductType { get; set; }
        public int QuoteId { get; set; }
    }
}
