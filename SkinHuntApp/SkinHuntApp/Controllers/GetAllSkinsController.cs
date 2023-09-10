using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkinHunt.Application.Commands;

namespace SkinHunt.Service.Controllers
{
    [Route("api/skins")]
    [AllowAnonymous]
    [ApiController]
    public class GetAllSkinsController : AppControllerBase
    {
        private readonly IMediator _mediator;

        public GetAllSkinsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<object> GetAllSkinsAsync()
        {
            var result = await _mediator.Send(new GetSkinsCommand());

            if (result is not null)
            {
                return result;
            }

            return null;
        }
    }
}
