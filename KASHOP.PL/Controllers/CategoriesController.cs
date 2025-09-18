using KASHOP.BLL.Services.CategoryServices;
using KASHOP.DAL.DTOs.CategoryDTOs.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KASHOP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //// GET: api/categories
        //[HttpGet("")]
        //public async Task<IActionResult> GetAll()
        //{
        //    var result = await _categoryService.GetAllAsync();
        //    return Ok(result);
        //}

        //// GET: api/categories/active
        //[HttpGet("active")]
        //public async Task<IActionResult> GetActiveCategories()
        //{
        //    var result = await _categoryService.GetActiveAsync();
        //    return Ok(new { message = "Success", data = result });
        //}

        //// GET: api/categories/{id}
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById([FromRoute] int id)
        //{
        //    var result = await _categoryService.GetByIdAsync(id);
        //    return result == null
        //        ? NotFound(new { message = "Category not found" })
        //        : Ok(result);
        //}

        //// POST: api/categories
        //[HttpPost]
        //public async Task<IActionResult> Add([FromBody] CategoryRequestDTO dto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var Id = await _categoryService.AddAsync(dto);
        //    return CreatedAtAction(nameof(GetById), new { Id }, new { message = "Category added successfully", Id });
        //}

        //// PUT: api/categories/{id}
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CategoryRequestDTO dto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var updated = await _categoryService.UpdateAsync(id, dto);
        //    return updated == 0
        //        ? NotFound(new { message = "Category not found" })
        //        : Ok(new { message = "Category updated successfully" });
        //}

        //// DELETE: api/categories/{id}
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete([FromRoute] int id)
        //{
        //    var removed = await _categoryService.RemoveAsync(id);
        //    return removed == 0
        //        ? NotFound(new { message = "Category not found" })
        //        : Ok(new { message = "Category deleted successfully" });
        //}

        //// PATCH: api/categories/{id}/toggle-status
        //[HttpPatch("{id}/toggle-status")]
        //public async Task<IActionResult> ToggleStatus([FromRoute] int id)
        //{
        //    var toggled = await _categoryService.ToggleStatusAsync(id);
        //    return toggled == false
        //        ? NotFound(new { message = "Category not found" })
        //        : Ok(new { message = "Category status toggled successfully" });
        //}
    }
}
