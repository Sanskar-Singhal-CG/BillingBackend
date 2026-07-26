using BillingDB_Backend.Blob;
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
        private readonly BlobService _blobService;

        public BillingInvoiceService(AppDbContext context, BlobService blobService)
        {
            _context = context;
            _blobService = blobService;
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


        //Used ai for this 

        public async Task<InvoiceCreateResponse?> createInvoice(InvoiceRequest request)
        {
            var customer = await _context.Parties.FindAsync(request.CustomerId);

            var company = await _context.Companies.FindAsync(1);

            var productIds = request.Items.Select(item => item.ProductId).Distinct().ToList();

            var products = await _context.Products
                .Where(product => productIds.Contains(product.Id))
                .ToDictionaryAsync(product => product.Id);

            if (products.Count != productIds.Count)
            {
                return null;
            }

            var invoice = new Entities.Invoice
            {
                InvoiceNumber = $"INV-{Guid.NewGuid():N}",
                InvoiceDate = DateTime.UtcNow,
                CustomerId = customer.Id,
                CustomerName = customer.Name,
                CustomerPhone = customer.Phone,
                CustomerAddress = customer.BillingAddress,
                CustomerGSTIN = customer.GSTIN,
                CompanyName = company.Name,
                CompanyAddress = company.Address,
                CompanyGSTIN = company.GSTIN,
                CompanyPhone = company.Phone,
                CompanyEmail = company.Email,
                CompanySignatureUrl = company.SignatureUrl,
                CompanyBankName = company.BankName,
                CompanyBankAccount = company.BankAccount,
                CompanyBankIFSC = company.BankIFSC,
                SubTotal = request.SubTotal,
                TotalGst = request.TotalGst,
                GrandTotal = request.GrandTotal,
                Items = request.Items.Select(item =>
                {
                    var product = products[item.ProductId];

                    return new Entities.InvoiceItem
                    {
                        ProductId = product.Id,
                        ProductName = product.Name,
                        ModelNumber = product.ModelNumber,
                        HsnCode = product.HsnCode,
                        Quantity = item.Quantity,
                        Rate = item.Rate,
                        SubTotal = item.SubTotal,
                        GstRate = item.GstRate,
                        GstAmount = item.GstAmount,
                        Total = item.Total
                    };
                }).ToList()
            };

            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();

            return new InvoiceCreateResponse
            {
                InvoiceId = invoice.Id,
                InvoiceNumber = invoice.InvoiceNumber
            };
        }

        public async Task<InvoiceDetailsResponse?> getInvoice(int id)
        {
            var invoice = await _context.Invoices
                .AsNoTracking()
                .Include(invoice => invoice.Items)
                .FirstOrDefaultAsync(invoice => invoice.Id == id);

            if (invoice == null)
            {
                return null;
            }

            byte[]? signatureFile = null;
            if (!string.IsNullOrEmpty(invoice.CompanySignatureUrl))
            {
                var signatureStream = await _blobService.GetSignatureAsync(invoice.CompanySignatureUrl);
                if (signatureStream != null)
                {
                    using (signatureStream)
                    using (var memoryStream = new MemoryStream())
                    {
                        await signatureStream.CopyToAsync(memoryStream);
                        signatureFile = memoryStream.ToArray();
                    }
                }
            }

            return new InvoiceDetailsResponse
            {
                InvoiceId = invoice.Id,
                InvoiceNumber = invoice.InvoiceNumber,
                InvoiceDate = invoice.InvoiceDate,
                CustomerId = invoice.CustomerId,
                CustomerName = invoice.CustomerName,
                CustomerPhone = invoice.CustomerPhone,
                CustomerAddress = invoice.CustomerAddress,
                CustomerGSTIN = invoice.CustomerGSTIN,
                CompanyName = invoice.CompanyName,
                CompanyAddress = invoice.CompanyAddress,
                CompanyGSTIN = invoice.CompanyGSTIN,
                CompanyPhone = invoice.CompanyPhone,
                CompanyEmail = invoice.CompanyEmail,
                SignatureFile = signatureFile,
                CompanyBankName = invoice.CompanyBankName,
                CompanyBankAccount = invoice.CompanyBankAccount,
                CompanyBankIFSC = invoice.CompanyBankIFSC,
                SubTotal = invoice.SubTotal,
                TotalGst = invoice.TotalGst,
                GrandTotal = invoice.GrandTotal,
                Items = invoice.Items.OrderBy(item => item.Id).Select(item => new InvoiceItemDetailsResponse
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    ModelNumber = item.ModelNumber,
                    HsnCode = item.HsnCode,
                    Quantity = item.Quantity,
                    Rate = item.Rate,
                    SubTotal = item.SubTotal,
                    GstRate = item.GstRate,
                    GstAmount = item.GstAmount,
                    Total = item.Total
                }).ToList()
            };
        }

        public async Task<List<InvoiceIdNameDateResponse>> getInvoiceIdNameAndDate(int partyId)
        {
            var result = await _context.Invoices
                .Where(i => i.CustomerId == partyId)
                .Select(i => new InvoiceIdNameDateResponse
                {
                    Id = i.Id,
                    InvoiceNumber = i.InvoiceNumber,
                    InvoiceDate = i.InvoiceDate
                }).ToListAsync();

            return result;
        }
    }
}
