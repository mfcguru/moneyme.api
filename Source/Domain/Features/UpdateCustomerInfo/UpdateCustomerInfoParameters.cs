using MoneyMe.Api.Source.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MoneyMe.Api.Source.Domain.Features.UpdateCustomerInfo
{
    public class UpdateCustomerInfoParameters
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public TitleType Title { get; set; }

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
