namespace BillingDB_Backend.Models.Response
{
    public class PartyDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Phone { get; set; }
        public string? BillingAddress { get; set; }
        public string? GSTIN { get; set; }
    }
}
