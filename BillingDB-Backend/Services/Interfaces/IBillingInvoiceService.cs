using BillingDB_Backend.Models.Request;
using BillingDB_Backend.Models.Response;

namespace BillingDB_Backend.Services.Interfaces
{
    public interface IBillingInvoiceService
    {
        public Task<ProductPGResponse> getProductPG(ProductPGRequest request);
    }
}
