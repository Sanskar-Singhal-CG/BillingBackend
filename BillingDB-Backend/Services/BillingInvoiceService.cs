using BillingDB_Backend.Data;
using BillingDB_Backend.Models.Request;
using BillingDB_Backend.Models.Response;
using BillingDB_Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BillingDB_Backend.Services
{
    public class BillingInvoiceService : IBillingInvoiceService
    {

        private readonly AppDbContext _context;

        public BillingInvoiceService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductPGResponse> getProductPG(ProductPGRequest request)
        {
            var product = await _context.Products
                .Where(p => p.Id == request.ProductId)
                .Select(p => new
                {
                    p.BasePrice,
                    p.GstRate
                })
                .FirstOrDefaultAsync();

            decimal? customPrice = await _context.PartyProductPrices
                .Where(x => x.PartyId == request.PartyId && x.ProductId == request.ProductId)
                .Select(x => (decimal?) x.CustomPrice)
                .FirstOrDefaultAsync();

            return new ProductPGResponse { Price = customPrice ?? product.BasePrice, GstRate = product.GstRate };
        }
    }
}
