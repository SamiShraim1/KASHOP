using KASHOP.BLL.Services.BrandServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KASHOP.PL.Areas.Customer
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Customer")]
    [Authorize(Roles = "Customer")]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }


        // GET: api/Brands/active
        [HttpGet("active")]
        public async Task<IActionResult> GetActiveBrands()
        {
            var result = await _brandService.GetActiveAsync();
            return Ok(new { message = "Success", data = result });
        }

        // GET: api/Brands/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _brandService.GetByIdAsync(id);
            return result == null
                ? NotFound(new { message = "Brand not found" })
                : Ok(result);
        }

    }
}
