using BAL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMarket.Interface;
using MyMarket.Models;
using MyMarket.Services;
using static DAL.Enum;

namespace MyMarket.Controllers
{
    [Authorize(Roles="admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoryController()
        {
            _categoryService = new CategoryService();
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] Category category)
        {
            try
            {
                EnumResult action = _categoryService.Add(category);

                switch (action)
                {
                    case EnumResult.Success:
                        return Ok(category);
                    case EnumResult.Fail:
                        return BadRequest("Failed to add category");
                    default:
                        return StatusCode(500, new { message = "Internal server error" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            try
            {
                return Ok(_categoryService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }




        [HttpPut("{id}")]
        public IActionResult UpdateCategory([FromBody] Category category)
        {
            try
            {
                EnumResult action = _categoryService.Update(category);

                switch (action)
                {
                    case EnumResult.Success:
                        return Ok(category);
                    case EnumResult.Fail:
                        return BadRequest("Failed to update category");
                    default:
                        return StatusCode(500, new { message = "Internal server error" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                EnumResult action = _categoryService.Delete(id);

                switch (action)
                {
                    case EnumResult.Success:
                        return Ok("Category deleted successfully");
                    case EnumResult.Fail:
                        return BadRequest("Failed to delete category");
                    default:
                        return StatusCode(500, new { message = "Internal server error" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }
    }
    
}
