using MoneyMe.Api.Source.Domain.BaseModels;
using MoneyMe.Api.Source.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MoneyMe.Api.Source.Domain.Features.SubmitApplication
{
    public class SubmitApplicationParameters : QuoteModel
    {
        [Required]
        public ProductType ProductType { get; set; }
    }
}
