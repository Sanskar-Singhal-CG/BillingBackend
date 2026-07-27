using BillingDB_Backend.Models.Request;
using BillingDB_Backend.Models.Response;

namespace BillingDB_Backend.Services.Interfaces
{
    public interface IProductService
    {
        public Task<List<ProductDto>> getAllProducts();

        public Task<List<ProductIdAndName>> getProductIdName();

        public Task<ApiResponse> createProduct(ProductRequest request);

        public Task<ApiResponse> updateProduct(int id, ProductRequest request);

        public Task<ApiResponse> deleteProduct(int id);
    }
}
