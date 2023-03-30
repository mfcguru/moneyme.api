
namespace MoneyMe.Api.Source.Infrastructure.QuoteCalculator
{
    public static class QuoteCalculatorHelper
    {
        public static double Pmt(double yearlyInterestRate, int totalNumberOfMonths, double loanAmount)
        {
            //var rate = yearlyInterestRate / 100 / 12;
            //var denominator = Math.Pow((1 + rate), totalNumberOfMonths) - 1;
            //return (rate + (rate / denominator)) * loanAmount;

            var vbMnthlyPayment = Microsoft.VisualBasic.Financial.Pmt(yearlyInterestRate / 12, totalNumberOfMonths, -(loanAmount * (1 + yearlyInterestRate / 12)), 0, 0);

            return vbMnthlyPayment;
        }
    }
}
