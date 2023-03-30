namespace MoneyMe.Api.Source.Infrastructure.QuoteCalculator
{
    public class QuoteCalculatorModel
    {
        public double Pmt { get; set; }
        public double TotalAmount { get; set; }
        public double Repayments { get; set; }
    }

    public interface IQuoteCalculator
    {
        QuoteCalculatorModel Calculate(int terms, double interestRate, double loanAmount, double establishmentFee);
    }
}
