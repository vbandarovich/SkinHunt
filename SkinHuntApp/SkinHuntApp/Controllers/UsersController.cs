using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkinHunt.Domain.Constants;

namespace SkinHunt.Service.Controllers
{
    [Route("api/users")]
    [Authorize(Roles = "admin")]
    [ApiController]
    public class UsersController : AppControllerBase 
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<UsersController> _logger;

        public UsersController(UserManager<IdentityUser> userManager, ILogger<UsersController> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _userManager.GetUsersInRoleAsync(RolesConstants.User);

                if (users is not null)
                {
                    _logger.LogInformation("Get users was successeded.");
                    return Ok(users);
                }

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Get users failed with exception: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
