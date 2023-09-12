using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkinHunt.Application.Commands;
using SkinHunt.Domain.Constants;

namespace SkinHunt.Service.Controllers
{
    [Route("api/users")]
    [Authorize(Roles = "admin")]
    [ApiController]
    public class UsersController : AppControllerBase 
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IMediator mediator, ILogger<UsersController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _mediator.Send( new GetUsersCommand());

            if (result.Any())
            {
                return Ok(result);
            }

            return NoContent();
        }

    }
}
