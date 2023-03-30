using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyMe.Api.Source.Domain.Entities
{
    public class Quote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int? ProductType { get; set; }

        [Required]
        public double AmountRequired { get; set; }

        [Required]
        public int Term { get; set; }

        [Required]
        public DateTime DateRequested { get; set; } = DateTime.UtcNow;

        [Required]
        public int CustomerID { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
