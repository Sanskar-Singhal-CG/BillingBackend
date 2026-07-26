using BillingDB_Backend.Models.Request;
using BillingDB_Backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BillingDB_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }


        [HttpPatch]
        public async Task<IActionResult> updateCompanyDetails([FromForm] CompanyUpdateRequest request)
        {
            var result = await companyService.updateCompanyDetails(request);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> getCompanyDetails()
        {
            var result = await companyService.getCompanyDetails();
            return Ok(result);
        }
    }
}
