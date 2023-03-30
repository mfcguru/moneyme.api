using MoneyMe.Api.Source.Domain.Entities;
using MoneyMe.Api.Source.Domain.Enums;

namespace MoneyMe.Api.Source.Infrastructure.DataProvider
{
    public interface IDataProvider
    {
        Task<Quote> FindQuote(string quoteIdentifier);
        Task<Quote> FindQuote(string firstName, string lastName, DateTime dateOfBirth);
        Task<int> SaveQuote(string firstName, string lastName, DateTime dateOfBirth, TitleType title, string mobile, string email, double amountRequired, int term);
        Task UpdateQuote(int quoteId, string firstName, string lastName, DateTime dateOfBirth, TitleType title, string mobile, string email, double amountRequired, int term, ProductType? productType);
        Task UpdateQuote(int quoteId, double amountRequired, int term, ProductType? productType);
        Task UpdateCustomer(int customerId, string firstName, string lastName, DateTime dateOfBirth, TitleType title, string mobile, string email);
        Task<BlocklistedDomainName> FindBlocklistedDomainName(string domainName);
        Task<BlocklistedMobileNo> FindBlocklistedMobileNo(string mobileNo);
    }
}
