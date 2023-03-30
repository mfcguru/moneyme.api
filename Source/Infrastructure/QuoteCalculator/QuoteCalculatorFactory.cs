using MoneyMe.Api.Source.Domain.Enums;

namespace MoneyMe.Api.Source.Infrastructure.QuoteCalculator
{
    public class QuoteCalculatorFactory
    {
        public IQuoteCalculator CreateInstance(ProductType productType)
        {
            switch(productType)
            {
                case ProductType.ProductA:
                    return new ProductAQuoteCalculator();
                case ProductType.ProductB:
                    return new ProductBQuoteCalculator();
                case ProductType.ProductC:
                    return new ProductCQuoteCalculator();
                default:
                    throw new ArgumentException(nameof(productType));
            }
        }
    }
}
