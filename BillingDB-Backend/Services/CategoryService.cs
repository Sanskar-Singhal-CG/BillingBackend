using BillingDB_Backend.Data;
using BillingDB_Backend.Entities;
using BillingDB_Backend.Models.Request;
using BillingDB_Backend.Models.Response;
using BillingDB_Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BillingDB_Backend.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryDto>> getCategories()
        {
            var categories = await _context.Categories
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();

            return categories;
        }

        public async Task<ApiResponse> createCategory(CategoryRequest request)
        {
            var category = new Entities.Category
            {
                Name = request.Name
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return new ApiResponse { Message = "Category created successfully", Success = true };
        }

        public async Task<ApiResponse> editCategory(int id, CategoryRequest request)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null) return new ApiResponse { Message = "Resource Not Found", Success = false };


            category.Name = request.Name;
            category.UpdatedAt = DateTime.UtcNow;


            await _context.SaveChangesAsync();

            return new ApiResponse { Message = "Category updated successfully", Success = true };
        }

        public async Task<ApiResponse> deleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if(category == null) return new ApiResponse { Message= "Resource Not found", Success = false };

            _context.Categories.Remove(category);

            await _context.SaveChangesAsync();

            return new ApiResponse { Message = "Category deleted successfully", Success = true };

        }
    }
}
