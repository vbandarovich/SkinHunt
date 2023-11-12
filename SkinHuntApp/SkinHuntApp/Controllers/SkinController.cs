using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkinHunt.Application.Commands;
using SkinHunt.Application.Common.Entities;
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
        private readonly IMapper _mapper;

        public SkinController(IMediator mediator, ILogger<SkinController> logger, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddSkin([FromBody] SkinModel model)
        {
            try
            {
                var itemType = await _mediator.Send(new AddItemTypeCommand(model.Type));

                var skinEntity = _mapper.Map<SkinEntity>(model);
                skinEntity.Type = itemType;

                var result = await _mediator.Send(new AddSkinCommand(skinEntity));

                _logger.LogInformation($"Added skin to db. Name: {result.Name}, Type: category - {result.Type.Category}, " +
                    $"subcategory - {result.Type.Subcategory}, Float: {result.Float}");

                return Ok(result);
            }
            catch (Exception ex)
            {

                _logger.LogError("Unexpected error occured during add skin");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
