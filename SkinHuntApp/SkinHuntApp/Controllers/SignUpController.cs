using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkinHunt.Application.Commands;
using SkinHunt.Domain.Models;

namespace SkinHunt.Service.Controllers
{
    [Route("api/signUp")]
    [AllowAnonymous]
    [ApiController]
    public class SignUpController : AppControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<SignUpController> _logger;

        public SignUpController(IMediator mediator, ILogger<SignUpController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] SignUpModel model)
        {
            var result = await _mediator.Send(new SignUpCommand(model));

            if (result is not null)
            {
                return Ok(result);
            }

            return BadRequest();
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
