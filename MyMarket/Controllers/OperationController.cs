using Azure;
using BAL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using static DAL.Enum;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly OperationService _operationService;

        public OperationController()
        {
            _operationService = new OperationService();
        }

        [HttpPost]
        public IActionResult AddOperation([FromBody] Operationn operation)
        {
            try
            {
                EnumResult action = _operationService.Add(operation);

                switch (action)
                {
                    case EnumResult.Success:
                        return Ok(operation);
                    case EnumResult.Fail:
                        return BadRequest("Failed to add operation");
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
        public IActionResult GetAllOperations()
        {
            try
            {
                return Ok(_operationService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOperation([FromBody] Operationn operation)
        {
            try
            {
                EnumResult action = _operationService.Update(operation);

                switch (action)
                {
                    case EnumResult.Success:
                        return Ok(operation);
                    case EnumResult.Fail:
                        return BadRequest("Failed to update operation");
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
        public IActionResult DeleteOperation(int id)
        {
            try
            {
                EnumResult action = _operationService.Delete(id);

                switch (action)
                {
                    case EnumResult.Success:
                        return Ok("Operation deleted successfully");
                    case EnumResult.Fail:
                        return BadRequest("Failed to delete operation");
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
