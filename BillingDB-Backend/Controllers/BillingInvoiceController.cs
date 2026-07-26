using BillingDB_Backend.Models.Request;
using BillingDB_Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BillingDB_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingInvoiceController : ControllerBase
    {
        private readonly IBillingInvoiceService _billingInvoiceService; 
        
        public BillingInvoiceController(IBillingInvoiceService billingInvoiceService)
        {
            _billingInvoiceService = billingInvoiceService;
        }

        [HttpPost("getProdPG")]
        public async Task<IActionResult> getProductPG([FromBody] ProductPGRequest request)
        {
            var result = await _billingInvoiceService.getProductPG(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> createInvoice([FromBody] InvoiceRequest request)
        {
            var result = await _billingInvoiceService.createInvoice(request);
            if (result == null)
            {
                return NotFound();
            }

            return StatusCode(201, result);
        }
    }
}
