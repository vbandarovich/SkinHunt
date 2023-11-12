using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkinHunt.Domain.Constants;

namespace SkinHunt.Service.Controllers
{
    [Route("api/admin")]
    [Authorize(Roles = "admin")]
    [ApiController]
    public class AdminController : AppControllerBase
    {
        private readonly ILogger<AdminController> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminController(ILogger<AdminController> logger, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddToAdminRole([FromBody] Guid userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId.ToString());

                if (user is not null)
                {
                    var isAdmin = await _userManager.IsInRoleAsync(user, RolesConstants.Admin);

                    if (!isAdmin)
                    {
                        var result = await _userManager.AddToRoleAsync(user, RolesConstants.Admin);

                        if (result.Succeeded) 
                        {
                            _logger.LogInformation("Role assignment was successful.");
                            return Ok("Successfully.");
                        }              
                    }

                    _logger.LogError($"Failed to assign 'Admin' role to user with id {user.Id}.");
                    return BadRequest($"Failed to assign Admin role to user.");
                }

                _logger.LogInformation($"User with id {userId} not found.");
                return NotFound("User not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred: {ex.Message}.");
                return StatusCode(500, $"Internal server error: {ex.Message}.");
            }
        }
    }
}
