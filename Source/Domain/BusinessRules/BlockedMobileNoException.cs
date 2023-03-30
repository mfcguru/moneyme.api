using System.Net;

namespace MoneyMe.Api.Source.Domain.BusinessRules
{
    public class BlockedMobileNoException : BusinessRuleException
    {
        private const string message = "Blocked mobile no.";

        public BlockedMobileNoException() : base(HttpStatusCode.BadRequest, message) { }
    }
}
