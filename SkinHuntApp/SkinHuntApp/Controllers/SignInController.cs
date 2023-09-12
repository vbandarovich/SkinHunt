using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkinHunt.Application.Commands;
using SkinHunt.Domain.Models;

namespace SkinHunt.Service.Controllers
{
    [Route("api/signIn")]
    [AllowAnonymous]
    [ApiController]
    public class SignInController : AppControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<SignInController> _logger;

        public SignInController(IMediator mediator, ILogger<SignInController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SignInModel model)
        {
            var result = await _mediator.Send(new SignInCommand(model));

            if (result is not null)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
