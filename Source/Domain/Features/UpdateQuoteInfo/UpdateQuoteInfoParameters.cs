using MoneyMe.Api.Source.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MoneyMe.Api.Source.Domain.Features.UpdateQuoteInfo
{
    public class UpdateQuoteInfoParameters
    {
        [Required]
        public int QuoteId { get; set; }

        [Required]
        public double AmountRequired { get; set; }

        [Required]
        public int Term { get; set; }

        [Required]
        public ProductType ProductType { get; set; }
    }
}
