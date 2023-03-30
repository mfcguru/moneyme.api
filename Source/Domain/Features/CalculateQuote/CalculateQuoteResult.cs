namespace MoneyMe.Api.Source.Domain.Features.CalculateQuote
{
    public class CalculateQuoteResult
    {
        public CustomerInfoModel CustomerInfo { get; set; }
        public QuoteInfoModel QuoteInfo { get; set; }
        public VariablesModel Variables { get; set; }

        public class CustomerInfoModel
        {   
            public int CustomerId { get; set; }
            public int Title { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Mobile { get; set; }
            public string Email { get; set; }
            public DateTime DateOfBirth { get; set; }
        }

        public class QuoteInfoModel
        {
            public double FinanceAmount { get; set; }
            public double Repayments { get; set; }
            public double TotalAmount { get; set; }
            public double EstablishmentFee { get; set; }
            public double Interest { get; set; }
        }

        public class VariablesModel
        {
            public int QuoteId { get; set; }
            public int Term { get; set; }
            public int ProductType { get; set; }
        }
    }
}
