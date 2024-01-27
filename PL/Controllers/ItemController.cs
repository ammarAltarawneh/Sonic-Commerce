using BAL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMarket.Models;
using MyMarket.Services;
using static DAL.Enum;

namespace Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ItemService _itemService;

        public ItemController()
        {
            _itemService = new ItemService();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult AddItem([FromBody] Item item)
        {
            try
            {
                EnumResult action = _itemService.Add(item);

                switch (action)
                {
                    case EnumResult.Success:
                        return Ok(item);
                    case EnumResult.Fail:
                        return BadRequest("Failed to add item");
                    default:
                        return StatusCode(500, new { message = "Internal server error" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult GetAllItems()
        {
            try
            {
                return Ok(_itemService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateItem([FromBody] Item item)
        {
            try
            {
                EnumResult action = _itemService.Update(item);

                switch (action)
                {
                    case EnumResult.Success:
                        return Ok(item);
                    case EnumResult.Fail:
                        return BadRequest("Failed to update Item");
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
        public IActionResult DeleteItem(int id)
        {
            try
            {
                EnumResult action = _itemService.Delete(id);

                switch (action)
                {
                    case EnumResult.Success:
                        return Ok("Item deleted successfully");
                    case EnumResult.Fail:
                        return BadRequest("Failed to delete item");
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
