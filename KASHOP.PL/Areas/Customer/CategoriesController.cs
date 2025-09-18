using KASHOP.BLL.Services.CategoryServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KASHOP.PL.Areas.Customer
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Customer")]
    [Authorize(Roles = "Customer")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }



        // GET: api/categories/active
        [HttpGet("active")]
        public async Task<IActionResult> GetActiveCategories()
        {
            var result = await _categoryService.GetActiveAsync();
            return Ok(new { message = "Success", data = result });
        }

        // GET: api/categories/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _categoryService.GetByIdAsync(id);
            return result == null
                ? NotFound(new { message = "Category not found" })
                : Ok(result);
        }

    }
}
