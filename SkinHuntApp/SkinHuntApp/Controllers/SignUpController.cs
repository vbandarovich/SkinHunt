using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using SkinHunt.Domain.Models;

namespace SkinHunt.Service.Controllers
{
    [Route("api/authorization")]
    [ApiController]
    public class SignUpController : AppControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<SignUpController> _logger;

        public SignUpController(UserManager<IdentityUser> userManager, IConfiguration configuration, ILogger<SignUpController> logger)
        {
            _userManager = userManager;
            _configuration = configuration;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("createUser")]
        public async Task<object> Post(SignUpModel sugnUpModel)
        {
            try
            {
                var user = new IdentityUser
                {
                    UserName = sugnUpModel.Name,
                    Email = sugnUpModel.Email,
                };

                var result = await _userManager.CreateAsync(user, sugnUpModel.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "user");

                    _logger.LogInformation("User has been created");

                    return Ok(new
                    {
                        id = user.Id,
                        userName = user.UserName,
                        email = user.Email,
                    });
                }
                return Task.FromResult(false);

            }
            catch (Exception ex)
            {
                Log.Error($"SignInAsync was fail with exception: {ex.Message}");

                return null;
            }
            
        }

        [AllowAnonymous]
        [HttpPost("token")]
        public async Task<int> GetAccessToken(CancellationToken ct)
        {
            return await Task.FromResult(0);
        }

        [AllowAnonymous]
        [HttpGet("token/refresh")]
        public async Task<int> RefreshToken(CancellationToken ct)
        {
            return await Task.FromResult(0);
        }
    }
}
