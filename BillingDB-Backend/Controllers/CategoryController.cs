using BillingDB_Backend.Models.Request;
using BillingDB_Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BillingDB_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> getCategories()
        {
            var result = await categoryService.getCategories();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getCategoryById(int id)
        {
            var result = await categoryService.getCategoryById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> createCategory([FromBody] CategoryRequest request)
        {
            var result = await categoryService.createCategory(request);
            if (result.Success)
            {
                return StatusCode(201, result);
            }
            return BadRequest(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> editCategory(int id, [FromBody] CategoryRequest request)
        {
            var result = await categoryService.editCategory(id, request);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteCategory(int id)
        {
            var result = await categoryService.deleteCategory(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
    }
}
