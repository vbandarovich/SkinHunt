using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkinHunt.Application.Commands;
using SkinHunt.Application.Common.Entities;
using SkinHunt.Application.Extensions;
using SkinHunt.Application.Queries;

namespace SkinHunt.Service.Controllers
{
    [Route("api/users")]
    [Authorize]
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
        public async Task<List<BasketEntity>> GetSkinsFromBasketAsync()
        {
            try
            {
                if (HttpContext.Request.Headers.TryGetValue("Authorization", out var authHeader))
                {
                    var token = authHeader.ToString().Replace("Bearer ", "");

                    var id = await JwtTokenHandler.GetIdFromTokenAsync(token);

                    var skins = await _mediator.Send(new GetSkinsByUserIdFromBasketQuery(id));

                    _logger.LogInformation("Skins received successfully.");
                    return skins;
                }
                else
                {
                    _logger.LogInformation("An error occurred while receiving the token.");
                    return new List<BasketEntity>();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An unexpected error occurred while receiving the skin. Error message {ex}");
                return new List<BasketEntity>();
            }
            
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveSkinFromBasketAsync([FromBody] Guid skinId)
        {
            try
            {
                if (HttpContext.Request.Headers.TryGetValue("Authorization", out var authHeader))
                {
                    var token = authHeader.ToString().Replace("Bearer ", "");

                    var id = await JwtTokenHandler.GetIdFromTokenAsync(token);

                    var skin = await _mediator.Send(new GetSkinByIdFromBasketQuery(id, skinId));

                    if (skin is not null)
                    {
                        await _mediator.Send(new RemoveSkinFromBasketCommand(skin));

                        return Ok();
                    }

                    return BadRequest();
                }
                else
                {
                    _logger.LogInformation("An error occurred while receiving the token.");
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("An unexpected error occurred while deleting the skin.");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
