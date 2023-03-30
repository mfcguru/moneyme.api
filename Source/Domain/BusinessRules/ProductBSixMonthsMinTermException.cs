using System.Net;

namespace MoneyMe.Api.Source.Domain.BusinessRules
{
    public class ProductBSixMonthsMinTermException : BusinessRuleException
    {
        private const string message = "Product B requires a minimum of six months term";

        public ProductBSixMonthsMinTermException() : base(HttpStatusCode.BadRequest, message) {}
    }
}
