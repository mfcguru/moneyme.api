using MoneyMe.Api.Source.Domain.BaseModels;
using MoneyMe.Api.Source.Domain.Enums;

namespace MoneyMe.Api.Source.Domain.Features.PreCalculateQuote
{
    public class PreCalculateQuoteParameters : QuoteModel
    {
        public ProductType ProductType { get; set; }
    }
}
