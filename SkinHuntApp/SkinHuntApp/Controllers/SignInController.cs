using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkinHunt.Application.Common.Interfaces;
using SkinHunt.Domain.Models;

namespace SkinHunt.Service.Controllers
{
    [Route("api/signIn")]
    [AllowAnonymous]
    [ApiController]
    public class SignInController : AppControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<SignInController> _logger;
        private readonly IJwtExtension _jwtExtension;

        public SignInController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, 
            ILogger<SignInController> logger, IJwtExtension jwtExtension)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _jwtExtension = jwtExtension;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SignInModel model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user is not null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, false, true);

                    if (result.Succeeded)
                    {
                        _logger.LogInformation("Login successeded.");

                        var token = await _jwtExtension.GenerateTokenAsync(user);

                        return Ok(token);
                    }

                    _logger.LogError("Login failed: password was incorrect.");
                    return Unauthorized("Password was incorrect.");
                }            

                _logger.LogError("Login failed: user not found.");
                return NotFound("User not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Login failed with exception: {ex.Message}");
                return BadRequest("Login failed with exception.");
            }
        }
    }
}
