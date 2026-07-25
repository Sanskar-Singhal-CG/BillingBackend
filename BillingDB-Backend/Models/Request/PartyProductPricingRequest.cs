using System.ComponentModel.DataAnnotations;

namespace BillingDB_Backend.Models.Request
{
    public class PartyProductPricingRequest
    {
        [Required]
        public int PartyId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public decimal CustomPrice { get; set; }
    }
}
