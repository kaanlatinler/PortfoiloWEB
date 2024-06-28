using Microsoft.AspNetCore.Mvc;
using PortfoiloAPI.DTO.Admin;
using PortfoiloAPI.Interface;

namespace PortfoiloAPI.Controllers.Admin
{
    [Route("api/Admin/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CategoryDTO categoryDTO)
        {
            var cat = await _categoryRepository.AddCategoryAsync(categoryDTO);
            if (cat == null)
            {
                return BadRequest();
            }
            return Ok(cat);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] Guid catID)
        {
            bool isDeleted = await _categoryRepository.DeleteCategoryAsync(catID);

            if (isDeleted)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
           var categories = await _categoryRepository.GetCategoriesAsync();

            return Ok(categories);
        }
    }
}
