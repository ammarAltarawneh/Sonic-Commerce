﻿using BAL.Services;
using Controllers;
using DAL;
using DAL.Managers;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
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
        private readonly IUser _user;

        public CategoryController(IConfiguration configuration, IUser user)
            : base(configuration, user)
        {
            _user = user;
            _categoryService = new CategoryService(_user);
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
                    CategoryService categories = new CategoryService(currentUser);
                    return Ok(categories.GetAll());
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
