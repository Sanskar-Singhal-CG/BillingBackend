using BillingDB_Backend.Models.Response;
using BillingDB_Backend.Models.Request;

namespace BillingDB_Backend.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<List<CategoryDto>> getCategories();
        public Task<CategoryDto> getCategoryById(int id);

        public Task<ApiResponse> createCategory(CategoryRequest request);

        public Task<ApiResponse> editCategory(int id, CategoryRequest request);

        public Task<ApiResponse> deleteCategory(int id);
    }
}
