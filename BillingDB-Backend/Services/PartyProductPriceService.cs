using BillingDB_Backend.Data;
using BillingDB_Backend.Models.Request;
using BillingDB_Backend.Models.Response;
using BillingDB_Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BillingDB_Backend.Services
{
    public class PartyProductPriceService : IPartyProductPriceService
    {

        private readonly AppDbContext _context;

        public PartyProductPriceService(AppDbContext context)
        {
            _context = context;
        }

        public Task<List<PartyProductPriceDto>> getAllPartyProductPricingByPartyId(int partyId)
        {
            var partyProductPrices = _context.PartyProductPrices
                .Where(p => p.PartyId == partyId)
                .Select(p => new PartyProductPriceDto
                {
                    Id = p.Id,
                    ProductName = p.Product.Name,
                    ModelNumber = p.Product.ModelNumber,
                    HsnCode = p.Product.HsnCode,
                    CategoryName = p.Product.Category.Name,
                    BasePrice = p.Product.BasePrice,
                    CustomPrice = p.CustomPrice,
                    GstRate = p.Product.GstRate

                }).ToListAsync();

            return partyProductPrices;
        }

        public async Task<ApiResponse> createPartyProductPricingByPartyId(PartyProductPricingRequest request)
        {
            var partyProductPrice = new Entities.PartyProductPrice
            {
                PartyId = request.PartyId,
                ProductId = request.ProductId,
                CustomPrice = request.CustomPrice,
                UpdatedAt = DateTime.UtcNow
            };

            _context.PartyProductPrices.Add(partyProductPrice);
            await _context.SaveChangesAsync();

            return new ApiResponse
            {
                Success = true,
                Message = "Party product pricing created successfully."
            };
        }

        public async Task<ApiResponse> updatePartyProductPricingById(int id, decimal customPrice)
        {
            var partyProductPrice = await _context.PartyProductPrices.FindAsync(id);

            if (partyProductPrice == null) return new ApiResponse { Message= "Party product pricing not found.", Success = false };

            partyProductPrice.CustomPrice = customPrice;

            _context.PartyProductPrices.Add(partyProductPrice);
            await _context.SaveChangesAsync();

            return new ApiResponse
            {
                Message = "Party product pricing updated successfully.",
                Success = true
            };
        }

        public async Task<ApiResponse> deletePartyProductPricingById(int id) {             
            var partyProductPrice = await _context.PartyProductPrices.FindAsync(id);

            if (partyProductPrice == null) return new ApiResponse { Message= "Party product pricing not found.", Success = false };

            _context.PartyProductPrices.Remove(partyProductPrice);
            await _context.SaveChangesAsync();

            return new ApiResponse
            {
                Message = "Party product pricing deleted successfully.",
                Success = true
            };
        }
    }
}
