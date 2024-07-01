using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkinHunt.Application.Commands;
using SkinHunt.Application.Common.Models;
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

        [HttpGet]
        public async Task<ActionResult> GetSkinsFromBasket([FromBody] string userId)
        {
            try
            {
                await _mediator.Send(new GetSkinsFromBasketQuery(userId));

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error with message: {ex}.");
                return StatusCode(500, $"Internal server error: {ex.Message}.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddSkinToBasket([FromBody] BasketModel model)
        {
            try
            {
                await _mediator.Send(new AddSkinToBasketCommand(model.User, model.Skin));

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error with message: {ex}.");
                return StatusCode(500, $"Internal server error: {ex.Message}.");
            }
        }
    }
}
