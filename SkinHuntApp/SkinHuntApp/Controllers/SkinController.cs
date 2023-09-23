using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkinHunt.Application.Commands;
using SkinHunt.Application.Common.Models;

namespace SkinHunt.Service.Controllers
{
    [Route("api/skin")]
    [Authorize(Roles = "admin")]
    [ApiController]
    public class SkinController : AppControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<SkinController> _logger;

        public SkinController(IMediator mediator, ILogger<SkinController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddSkinToDb([FromBody] SkinModel model)
        {
            var success = await _mediator.Send(new AddSkinDbCommand(model));

            if (success)
            {
                return Ok("successed.");
            }

            return BadRequest("Failed to add the skin. Invalid skin data.");
        }
    }
}
