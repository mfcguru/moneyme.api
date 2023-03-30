namespace MoneyMe.Api.Source.Infrastructure.QuoteCalculator
{
    public class ProductBQuoteCalculator : BaseQuoteCalculator, IQuoteCalculator
    {
        public QuoteCalculatorModel Calculate(int terms, double interestRate, double loanAmount, double establishmentFee)
        {
            var pmt = QuoteCalculatorHelper.Pmt(interestRate, terms, loanAmount);
            var totalAmount = pmt + loanAmount + establishmentFee;

            return new QuoteCalculatorModel
            {
                Pmt = Math.Round(pmt, 2),
                Repayments = Math.Round(totalAmount / (terms * WEEKS_IN_MONTH), 2),
                TotalAmount = Math.Round(totalAmount, 2)
            };
        }
    }
}
