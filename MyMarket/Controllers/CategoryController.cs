using BAL.Services;
using Controllers;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMarket.Models;
using MyMarket.Services;
using static DAL.Enum;

namespace MyMarket.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : SharedController
    {
        private readonly CategoryService _categoryService;

        public CategoryController(IConfiguration configuration):base(configuration)
        {
            _categoryService = new CategoryService();
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            
            try
            {
                var currentUser = CurrentUser;

                if (currentUser != null)
                {
                    var categories = _categoryService.GetAllCategoriesByAuthUser(currentUser);
                    return Ok(categories);
                }
                return Unauthorized(new { message = "User not authenticated." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }
        [Authorize(Roles = "admin")]
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

        [Authorize(Roles = "admin")]
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

        [Authorize(Roles = "admin")]
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
