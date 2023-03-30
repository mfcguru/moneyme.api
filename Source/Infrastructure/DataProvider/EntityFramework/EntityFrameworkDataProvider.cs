using Microsoft.EntityFrameworkCore;
using MoneyMe.Api.Source.Domain.Entities;
using MoneyMe.Api.Source.Domain.Enums;
using MoneyMe.Api.Source.Infrastructure.RedirectUrlGenerator;
using System.Reflection;

namespace MoneyMe.Api.Source.Infrastructure.DataProvider.EntityFramework
{
    public class EntityFrameworkDataProvider : IDataProvider
    {
        private readonly DataContext context;
        private readonly IRedirectUrlGenerator urlGenerator;

        public EntityFrameworkDataProvider(DataContext context, IRedirectUrlGenerator urlGenerator)
        {
            this.context = context;
            this.urlGenerator = urlGenerator;
        }

        public async Task<Quote> FindQuote(string firstName, string lastName, DateTime dateOfBirth)
        {
            var query = context.Quotes
                .Include(o => o.Customer)
                .Where(o =>
                    o.Customer.FirstName.ToLower() == firstName.ToLower() &&
                    o.Customer.LastName.ToLower() == lastName.ToLower() &&
                    o.Customer.DateOfBirth.Date == dateOfBirth.Date)
                .OrderByDescending(o => o.DateRequested)
                .Take(1);

            return await query.SingleOrDefaultAsync();
        }

        public async Task<Quote> FindQuote(string quoteIdentifier)
        {
            var id = urlGenerator.GenerateIdFromString(quoteIdentifier);

            return await context.Quotes
                .Include(o => o.Customer)
                .SingleOrDefaultAsync(o => o.ID == id);
        }

        public async Task<int> SaveQuote(string firstName, string lastName, DateTime dateOfBirth, TitleType title, string mobile, string email, double amountRequired, int term)
        {
            var quote = new Quote
            {
                AmountRequired = amountRequired,
                Term = term,
                Customer = new Customer
                {
                    FirstName = firstName,
                    LastName = lastName,
                    DateOfBirth = dateOfBirth,
                    Email = email,
                    Mobile = mobile,
                    Title = (int)title
                }
            };

            context.Quotes.Add(quote);

            await context.SaveChangesAsync();

            return quote.ID;
        }

        public async Task<int> SaveQuoteRequest(int customerId, double amountRequired, int term)
        {
            var quotation = new Quote
            {
                AmountRequired = amountRequired,
                Term = term,
                CustomerID = customerId
            };

            context.Quotes.Add(quotation);

            await context.SaveChangesAsync();

            return quotation.CustomerID;
        }

        public async Task UpdateQuote(int quoteId, string firstName, string lastName, DateTime dateOfBirth, TitleType title, string mobile, string email, double amountRequired, int term, ProductType? productType)
        {
            var quote = await context.Quotes
                .Include(o => o.Customer)
                .SingleOrDefaultAsync(o => o.ID == quoteId);
            
            if (quote != null)
            {
                quote.Term = term;
                quote.AmountRequired = amountRequired;
                quote.Customer.FirstName = firstName;
                quote.Customer.LastName = lastName;
                quote.Customer.DateOfBirth = dateOfBirth;
                quote.Customer.Email = email;
                quote.Customer.Title = (int)title;
                quote.Customer.Mobile = mobile;
                quote.ProductType = (int?)productType;    

                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateQuote(int quoteId, double amountRequired, int term, ProductType? productType)
        {
            var quote = await context.Quotes
                .SingleOrDefaultAsync(o => o.ID == quoteId);

            if (quote != null)
            {
                quote.Term = term;
                quote.AmountRequired = amountRequired;
                quote.ProductType = (int?)productType;

                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateCustomer(int customerId, string firstName, string lastName, DateTime dateOfBirth, TitleType title, string mobile, string email)
        {
            var customer = await context.Customers.FindAsync(customerId);
            if (customer != null)
            {
                customer.FirstName = firstName;
                customer.LastName = lastName;   
                customer.DateOfBirth = dateOfBirth;
                customer.Mobile = mobile;
                customer.Email = email;
                customer.DateOfBirth = dateOfBirth;
                customer.Title = (int)title;

                await context.SaveChangesAsync();   
            }
        }

        public async Task<BlocklistedDomainName> FindBlocklistedDomainName(string domainName)
        {
            return await context.BlocklistedDomainNames
                .AsNoTracking()
                .SingleOrDefaultAsync(o => o.DomainName.ToLower() == domainName.ToLower());
        }

        public async Task<BlocklistedMobileNo> FindBlocklistedMobileNo(string mobileNo)
        {
            return await context.BlocklistedMobileNos
                .AsNoTracking()
                .SingleOrDefaultAsync(o => o.MobileNo.ToLower() == mobileNo.ToLower());
        }
    }
}
