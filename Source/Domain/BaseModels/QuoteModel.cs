using System.ComponentModel.DataAnnotations;

namespace MoneyMe.Api.Source.Domain.BaseModels
{
    public class QuoteModel
    {
        [Required]
        public double AmountRequired { get; set; }

        [Required]
        public int Term { get; set; }

        [Required]
        public int Title { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
