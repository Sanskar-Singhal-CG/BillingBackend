using BillingDB_Backend.Models.Request;
using BillingDB_Backend.Models.Response;

namespace BillingDB_Backend.Services.Interfaces
{
    public interface IPartyRequestService
    {
        public Task<ApiResponse> createParty(PartyRequest request);
        public Task<ApiResponse> updateParty(int id, PartyRequest request);

        public Task<List<PartyDto>> getAllParty();

        public Task<PartyDto> getPartyById(int id);

        public Task<ApiResponse> deleteParty(int id);
    }
}
