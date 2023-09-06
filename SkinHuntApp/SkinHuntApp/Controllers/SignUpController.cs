using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkinHunt.Application.Common.Interfaces;
using SkinHunt.Domain.Constants;
using SkinHunt.Domain.Models;

namespace SkinHunt.Service.Controllers
{
    [Route("api/signUp")]
    [AllowAnonymous]
    [ApiController]
    public class SignUpController : AppControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<SignUpController> _logger;
        private readonly IJwtExtension _jwtExtension;

        public SignUpController(UserManager<IdentityUser> userManager, ILogger<SignUpController> logger,
            IJwtExtension jwtExtension)
        {
            _userManager = userManager;
            _logger = logger;
            _jwtExtension = jwtExtension;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] SignUpModel model)
        {
            try
            {
                var user = new IdentityUser
                {
                    UserName = model.Username,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, RolesConstants.User);

                    _logger.LogInformation("User has been created.");

                    var token = await _jwtExtension.GenerateTokenAsync(user);

                    return Ok(token);
                }

                _logger.LogInformation($"User not created. Errors: {result.Errors.First()}.");
                return Unauthorized("User not created.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Sign in failed with exception: {ex.Message}.");
                return BadRequest("Sign in failed.");
            } 
        }

        [HttpPost("token")]
        public async Task<int> GetAccessToken(CancellationToken ct)
        {
            return await Task.FromResult(0);
        }

        [HttpGet("token/refresh")]
        public async Task<int> RefreshToken(CancellationToken ct)
        {
            return await Task.FromResult(0);
        }
    }
}
