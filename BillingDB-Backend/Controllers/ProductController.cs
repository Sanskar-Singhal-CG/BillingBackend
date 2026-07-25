using BillingDB_Backend.Models.Request;
using BillingDB_Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BillingDB_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> getAllProducts()
        {
            var result = await productService.getAllProducts();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getProduct(int id)
        {
            var result = await productService.getProduct(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> createProduct([FromBody] ProductRequest request)
        {
            var result = await productService.createProduct(request);
            if (result.Success)
            {
                return StatusCode(201, result);
            }
            return BadRequest(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> updateProduct(int id, [FromBody] ProductRequest request)
        {
            var result = await productService.updateProduct(id, request);
            if (result.Success)
            {
                return StatusCode(200, result);
            }
            return NotFound(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteProduct(int id)
        {
            var result = await productService.deleteProduct(id);
            if (result.Success)
            {
                return StatusCode(200, result);
            }
            return NotFound(result);
        }
    }
}
