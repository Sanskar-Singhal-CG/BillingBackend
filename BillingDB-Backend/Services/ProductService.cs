using BillingDB_Backend.Data;
using BillingDB_Backend.Models.Request;
using BillingDB_Backend.Models.Response;
using BillingDB_Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BillingDB_Backend.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDto>> getAllProducts()
        {
            var products = await _context.Products
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    ModelNumber = p.ModelNumber,
                    HsnCode = p.HsnCode,
                    BasePrice = p.BasePrice,
                    GstRate = p.GstRate,
                    Category = p.Category != null ? new CategoryDto
                    {
                        Id = p.Category.Id,
                        Name = p.Category.Name
                    } : null
                }).ToListAsync();

            return products;
        }

        public async Task<ProductDto> getProduct(int id)
        {
            var product = await _context.Products.Where(p => p.Id == id)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    ModelNumber = p.ModelNumber,
                    HsnCode = p.HsnCode,
                    BasePrice = p.BasePrice,
                    GstRate = p.GstRate,
                    Category = p.Category != null ? new CategoryDto
                    {
                        Id = p.Category.Id,
                        Name = p.Category.Name
                    } : null
                }).FirstOrDefaultAsync();

            if (product == null)
            {
                return null;
            }

            return product;
        }

        public async Task<List<ProductIdAndName>> getProductIdName()
        {
            var products = await _context.Products
                .Select(p => new ProductIdAndName
                {
                    Id = p.Id,
                    Name = p.Name
                }).ToListAsync();
            return products;
        }

        public async Task<ApiResponse> createProduct(ProductRequest request)
        {
            var product = new Entities.Product
            {
                Name = request.Name,
                ModelNumber = request.ModelNumber,
                HsnCode = request.HsnCode,
                BasePrice = request.BasePrice,
                GstRate = request.GstRate,
                CategoryId = request.CategoryId
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return new ApiResponse { Message = "Created Successfully", Success = true };
        }

        public async Task<ApiResponse> updateProduct(int id, ProductRequest request)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return new ApiResponse { Message = "Product not found", Success = false };
            }

            product.Name = request.Name;
            product.ModelNumber = request.ModelNumber;
            product.HsnCode = request.HsnCode;
            product.BasePrice = request.BasePrice;
            product.GstRate = request.GstRate;
            product.CategoryId = request.CategoryId;
            product.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return new ApiResponse { Message = "Updated Successfully", Success = true };
        }

        public async Task<ApiResponse> deleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return new ApiResponse { Message = "Product not found", Success = false };
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return new ApiResponse { Message = "Deleted Successfully", Success = true };
        }
    }
}
