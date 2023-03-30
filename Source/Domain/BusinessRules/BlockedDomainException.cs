using System.Net;

namespace MoneyMe.Api.Source.Domain.BusinessRules
{
    public class BlockedDomainException : BusinessRuleException
    {
        private const string message = "Blocked domain";

        public BlockedDomainException() : base(HttpStatusCode.BadRequest, message) { }
    }
}
