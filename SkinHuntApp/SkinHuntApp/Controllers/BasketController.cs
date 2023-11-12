using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkinHunt.Application.Commands;
using SkinHunt.Application.Common.Models;
using SkinHunt.Application.Extensions;
using SkinHunt.Application.Queries;

namespace SkinHunt.Service.Controllers
{
    [Route("api/basket")]
    [Authorize]
    [ApiController]
    public class BasketController : AppControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<BasketController> _logger;
        
        public BasketController(IMediator mediator, ILogger<BasketController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddSkinToBasket([FromBody] Guid skinId)
        {
            try
            {
                if (HttpContext.Request.Headers.TryGetValue("Authorization", out var authHeader))
                {
                    var token = authHeader.ToString().Replace("Bearer ", "");

                    var id = await JwtTokenHandler.GetIdFromTokenAsync(token);

                    var user = await _mediator.Send(new GetUserByTokenQuery(id));

                    var skin = await _mediator.Send(new GetSkinByIdQuery(skinId));

                    var model = new BasketModel()
                    {
                        UserId = user,
                        SkinId = skin,
                        Data = DateTime.Now
                    };

                    await _mediator.Send(new AddSkinToBasketCommand(model));

                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error with message: {ex}.");
                return StatusCode(500, $"Internal server error: {ex.Message}.");
            }
            
        }
    }
}
