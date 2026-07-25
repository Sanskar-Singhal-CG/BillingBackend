using BillingDB_Backend.Models.Request;
using BillingDB_Backend.Models.Response;

namespace BillingDB_Backend.Services.Interfaces
{
    public interface IPartyProductPriceService
    {

        public Task<List<PartyProductPriceDto>> getAllPartyProductPricingByPartyId(int partyId);
        public Task<ApiResponse> createPartyProductPricingByPartyId(PartyProductPricingRequest request);

        public Task<ApiResponse> updatePartyProductPricingById(int id, decimal customPrice);

        public Task<ApiResponse> deletePartyProductPricingById(int id);
    }
}
