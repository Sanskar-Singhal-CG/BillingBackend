using System.ComponentModel.DataAnnotations;

namespace BillingDB_Backend.Models.Request
{
    public class CategoryRequest
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
