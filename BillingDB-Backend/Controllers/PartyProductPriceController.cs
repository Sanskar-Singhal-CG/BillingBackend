using BillingDB_Backend.Models.Request;
using BillingDB_Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BillingDB_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartyProductPriceController : ControllerBase
    {
        private readonly IPartyProductPriceService partyProductPriceService;

        public PartyProductPriceController(IPartyProductPriceService partyProductPriceService)
        {
            this.partyProductPriceService = partyProductPriceService;
        }

        [HttpGet("{partyId}")]
        public async Task<IActionResult> getAllPartyProductPricingByPartyId(int partyId)
        {
            var result = await partyProductPriceService.getAllPartyProductPricingByPartyId(partyId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> createPartyProductPricingByPartyId([FromBody] PartyProductPricingRequest request)
        {
            var result = await partyProductPriceService.createPartyProductPricingByPartyId(request);
            if (result.Success)
            {
                return StatusCode(201, result);
            }
            return BadRequest(result);
        }

        [HttpPatch("{id}/{customPrice}")]
        public async Task<IActionResult> updatePartyProductPricingById(int id, decimal customPrice)
        {
            var result = await partyProductPriceService.updatePartyProductPricingById(id, customPrice);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deletePartyProductPricingById(int id)
        {
            var result = await partyProductPriceService.deletePartyProductPricingById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
    }
}
