
namespace MoneyMe.Api.Source.Infrastructure.QuoteCalculator
{
    public class ProductAQuoteCalculator : BaseQuoteCalculator, IQuoteCalculator
    {
        public QuoteCalculatorModel Calculate(int terms, double interestRate, double loanAmount, double establishmentFee)
        {
            var totalAmount = loanAmount + establishmentFee;

            return new QuoteCalculatorModel
            {
                Pmt = 0,
                Repayments = Math.Round(totalAmount / (terms * WEEKS_IN_MONTH), 2),
                TotalAmount = Math.Round(totalAmount, 2)
            };
        }
    }
}
