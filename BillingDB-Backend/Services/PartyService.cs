using BillingDB_Backend.Services.Interfaces;
using BillingDB_Backend.Models.Request;
using BillingDB_Backend.Models.Response;
using BillingDB_Backend.Entities;
using BillingDB_Backend.Data;
using Microsoft.EntityFrameworkCore;
namespace BillingDB_Backend.Services
{
    public class PartyService : IPartyService
    {
        private readonly AppDbContext _context;

        public PartyService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse> createParty(PartyRequest request)
        {
            var party = new Party
            {
                Name = request.Name,
                BillingAddress = request.BillingAddress,
                Phone = request.Phone,
                GSTIN = request.GSTIN
            };

            _context.Parties.Add(party);
            await _context.SaveChangesAsync();
            return new ApiResponse { Message = "Party created successfully", Success = true };
        }

        public async Task<ApiResponse> updateParty(int id, PartyRequest request)
        {
            var party = await _context.Parties.FindAsync(id);
            if (party == null) return new ApiResponse { Message = "Bad Request", Success = false };

            party.Name = request.Name;
            party.BillingAddress = request.BillingAddress;
            party.Phone = request.Phone;
            party.GSTIN = request.GSTIN;
            party.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return new ApiResponse { Message = "Party updated successfully", Success = true };
        }

        public async Task<List<PartyDto>> getAllParty()
        {
            var parties = await _context.Parties
                .Select(p => new PartyDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    BillingAddress = p.BillingAddress,
                    Phone = p.Phone,
                    GSTIN = p.GSTIN
                }).ToListAsync();

            return parties;
        }

        public async Task<List<PartyIdNameDto>> getPartiesIdn()
        {
            var parties = await _context.Parties
                .Select(p => new PartyIdNameDto
                {
                    id = p.Id,
                    name = p.Name
                }).ToListAsync();

            return parties;
        }
    }
}
