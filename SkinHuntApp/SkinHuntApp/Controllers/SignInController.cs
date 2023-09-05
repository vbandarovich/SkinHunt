using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using SkinHunt.Domain.Models;

namespace SkinHunt.Service.Controllers
{
    [Route("api/authorization")]
    [ApiController]
    public class SignInController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<SignInController> _logger;

        public SignInController(UserManager<IdentityUser> userManager, IConfiguration configuration, SignInManager<IdentityUser> signInManager, ILogger<SignInController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager; 
            _configuration = configuration;
            _logger = logger;  
        }

        [HttpPost]
        public async Task<object> Post(SignInModel signInModel)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(signInModel.Email);

                var result = await _signInManager.PasswordSignInAsync(user.UserName, signInModel.Password, false, true);

                if (result.Succeeded)
                {
                    _logger.LogInformation("Login operation was successfully");

                    return Ok(new
                    {
                        id = user.Id,
                        userName = user.UserName,
                        email = user.Email,
                        roles = await _userManager.GetRolesAsync(user)
                    });
                }

                _logger.LogError("Login operation was fail: user not found");

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Login operation was fail with exception: {ex.Message}");

                return null;
            }
        }
    }
}
