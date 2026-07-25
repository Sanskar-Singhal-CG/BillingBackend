using System.ComponentModel.DataAnnotations;

namespace BillingDB_Backend.Models.Request
{
    public class PartyRequest
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string? Phone { get; set; }

        [Required]
        public string? BillingAddress { get; set; }

        [Required]
        public string? GSTIN { get; set; }
    }
}
