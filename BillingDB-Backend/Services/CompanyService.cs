using BillingDB_Backend.Blob;
using BillingDB_Backend.Data;
using BillingDB_Backend.Models.Request;
using BillingDB_Backend.Models.Response;
using BillingDB_Backend.Services.Interfaces;


// I used ai here for configuration of the azure blob and the image file upload and for handling of file upload and download.

namespace BillingDB_Backend.Services
{
    public class CompanyService : ICompanyService
    {

        private readonly AppDbContext _context;
        private readonly BlobService _blobService;

        public CompanyService(AppDbContext context, BlobService blobService)
        {
            _context = context;
            _blobService = blobService;
        }

        public async Task<ApiResponse> updateCompanyDetails(CompanyUpdateRequest request)
        {
            int id = 1;

            var company = await _context.Companies.FindAsync(id);
            if (company == null)
                return new ApiResponse { Success = false };

            company.Name = request.Name;
            company.Address = request.Address;
            company.GSTIN = request.GSTIN;
            company.Phone = request.Phone;
            company.Email = request.Email;
            company.BankName = request.BankName;
            company.BankAccount = request.BankAccount;
            company.BankIFSC = request.BankIFSC;

            if (request.SignatureFile != null)
            {
                var url = await _blobService.UploadAsync(request.SignatureFile);
                company.SignatureUrl = url;
            }

            await _context.SaveChangesAsync();

            return new ApiResponse { Success = true };
        }

        public async Task<CompanyDto> getCompanyDetails()
        {
            int id = 1;
            var company = await _context.Companies.FindAsync(id);
            if (company == null) return null;

            var stream = await _blobService.GetSignatureAsync(company.SignatureUrl);
            using var memoryStream = new MemoryStream();
            await stream!.CopyToAsync(memoryStream);

            return new CompanyDto
            {
                Name = company.Name,
                Address = company.Address,
                GSTIN = company.GSTIN,
                Phone = company.Phone,
                Email = company.Email,
                BankName = company.BankName,
                BankAccount = company.BankAccount,
                BankIFSC = company.BankIFSC,
                SignatureFile = memoryStream.ToArray()
            };
        }
    }
}
