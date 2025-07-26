using KASHOP.BLL.Services.BrandServices;
using KASHOP.DAL.DTOs.BrandDTOs.Requests;
using KASHOP.DAL.DTOs.CategoryDTOs.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KASHOP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }


        // GET: api/Brands
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _brandService.GetAllAsync();
            return Ok(result);
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
        // POST: api/Brands
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BrandRequestDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Id = await _brandService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { Id }, new { message = "Brand added successfully", Id });
        }

        // PUT: api/Brands/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] BrandRequestDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _brandService.UpdateAsync(id, dto);
            return updated == 0
                ? NotFound(new { message = "Brand not found" })
                : Ok(new { message = "Brand updated successfully" });
        }
        // DELETE: api/Brands/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var removed = await _brandService.RemoveAsync(id);
            return removed == 0
                ? NotFound(new { message = "Brand not found" })
                : Ok(new { message = "Brand deleted successfully" });
        }

        // PATCH: api/Brands/{id}/toggle-status
        [HttpPatch("{id}/toggle-status")]
        public async Task<IActionResult> ToggleStatus([FromRoute] int id)
        {
            var toggled = await _brandService.ToggleStatusAsync(id);
            return toggled == false
                ? NotFound(new { message = "Brand not found" })
                : Ok(new { message = "Brand status toggled successfully" });
        }

    }
}
