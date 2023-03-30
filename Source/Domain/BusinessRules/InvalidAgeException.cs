using System.Net;

namespace MoneyMe.Api.Source.Domain.BusinessRules
{
    public class InvalidAgeException : BusinessRuleException
    {
        private const string message = "Applicant should be at least 18 years old";

        public InvalidAgeException() : base(HttpStatusCode.BadRequest, message) { }
    }
}
