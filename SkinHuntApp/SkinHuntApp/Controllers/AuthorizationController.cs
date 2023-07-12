using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SkinHunt.Service.Controllers
{
    [Route("/authorization/")]
    [ApiController]
    public class AuthorizationController : AppControllerBase
    {
        public AuthorizationController()
        {              
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
