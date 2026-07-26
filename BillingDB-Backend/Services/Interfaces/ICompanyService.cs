using BillingDB_Backend.Models.Request;
using BillingDB_Backend.Models.Response;

namespace BillingDB_Backend.Services.Interfaces
{
    public interface ICompanyService
    {
        public Task<ApiResponse> updateCompanyDetails(CompanyUpdateRequest request);

        public Task<CompanyDto> getCompanyDetails();
    }
}
