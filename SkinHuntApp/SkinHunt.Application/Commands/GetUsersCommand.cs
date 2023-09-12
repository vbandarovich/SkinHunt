using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SkinHunt.Domain.Constants;
using Microsoft.AspNetCore.Mvc;

namespace SkinHunt.Application.Commands
{
    public class GetUsersCommand : IRequest<List<IdentityUser>>
    { 
    }

    public class GetUsersCommandHendler : IRequestHandler<GetUsersCommand, List<IdentityUser>>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<GetUsersCommandHendler> _logger;

        public GetUsersCommandHendler(UserManager<IdentityUser> userManager, ILogger<GetUsersCommandHendler> logger)
        {
            _userManager = userManager;
            _logger = logger;  
        }

        public async Task<List<IdentityUser>> Handle(GetUsersCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _userManager.GetUsersInRoleAsync(RolesConstants.User);

                if (users.Any())
                {
                    _logger.LogInformation("Get users was succeeded.");
                    return users.ToList();
                }

                return new List<IdentityUser>();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Get users failed with exception: {ex.Message}");
                return new List<IdentityUser>();
            }
        }
    }
}
