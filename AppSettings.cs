namespace MoneyMe.Api
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }
        public string RedirectUrl { get; set; }
        public double YearlyInterestRate { get; set; }
        public double EstablishmentFee { get; set; }
    }
}
