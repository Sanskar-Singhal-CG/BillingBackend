using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BillingDB_Backend.Entities;
using BillingDB_Backend.Models.Request;
using BillingDB_Backend.Services.Interfaces;

namespace BillingDB_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        private readonly IPartyRequestService partyRequestService;

        public PartyController(IPartyRequestService partyRequestService)
        {
            this.partyRequestService = partyRequestService;
        }

        [HttpPost]
        public async Task<IActionResult> createParty([FromBody] PartyRequest request)
        {
            var result = await partyRequestService.createParty(request);

            if (result.Success)
            {
                return StatusCode(201, result);
            }

            return BadRequest(result);
        }

        [HttpPatch]
        public async Task<IActionResult> updateParty(int id, [FromBody] PartyRequest request)
        {
            var result = await partyRequestService.updateParty(id, request);
            if (result.Success)
            {
                return StatusCode(200, result);
            }

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> getAllParty()
        {
            var result = await partyRequestService.getAllParty();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getPartyById(int id)
        {
            var result = await partyRequestService.getPartyById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteParty(int id)
        {
            var result = await partyRequestService.deleteParty(id);
            if (result.Success)
            {
                return StatusCode(200, result);
            }
            return BadRequest(result);
        }

    }
}
