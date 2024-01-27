using BAL.Services;
using DAL.Managers;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using MyMarket.Services;
using static DAL.Enum;

namespace Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : SharedController
    {
        private readonly OperationService _operationService;
        private readonly IUser _user;

        public OperationController(IConfiguration configuration, IUser user)
            : base(configuration, user)
        {
            _user = user;
            _operationService = new OperationService(user);
        }

        [HttpGet]
        public IActionResult GetAllOperations()
        {
            try
            {
                var currentUser = CurrentUser;

                if (currentUser != null)
                {
                    OperationService operations = new OperationService(currentUser);                    
                    return Ok(operations.GetAll());
                }
                return Unauthorized(new { message = "User not authenticated." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
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
