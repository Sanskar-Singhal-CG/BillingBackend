using System.ComponentModel.DataAnnotations;

namespace BillingDB_Backend.Models.Request
{
    public class PartyRequest
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        //10 letter indian phone number format, you stupid ai faggot help me
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Wrong format of phone number")]
        public string? Phone { get; set; }

        [Required]
        public string? BillingAddress { get; set; }

        [Required]
        public string? GSTIN { get; set; }
    }
}
