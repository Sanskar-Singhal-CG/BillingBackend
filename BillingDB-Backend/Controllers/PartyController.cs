using Microsoft.AspNetCore.Mvc;
using BillingDB_Backend.Models.Request;
using BillingDB_Backend.Services.Interfaces;

namespace BillingDB_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        private readonly IPartyService partyService;

        public PartyController(IPartyService partyService)
        {
            this.partyService = partyService;
        }

        [HttpPost]
        public async Task<IActionResult> createParty([FromBody] PartyRequest request)
        {
            var result = await partyService.createParty(request);

            if (result.Success)
            {
                return StatusCode(201, result);
            }

            return BadRequest(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> updateParty(int id, [FromBody] PartyRequest request)
        {
            var result = await partyService.updateParty(id, request);
            if (result.Success)
            {
                return StatusCode(200, result);
            }

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> getAllParty()
        {
            var result = await partyService.getAllParty();
            return Ok(result);
        }

        [HttpGet("idn")]
        public async Task<IActionResult> getPartiesIdn()
        {
            var result = await partyService.getPartiesIdn();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteParty(int id)
        {
            var result = await partyService.deleteParty(id);
            if (result.Success)
            {
                return StatusCode(200, result);
            }
            return BadRequest(result);
        }
    }
}
