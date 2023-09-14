using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SkinHunt.Domain.Constants;

namespace SkinHunt.Application.Queries
{
    public class GetUsersQuery : IRequest<List<IdentityUser>>
    {
    }

    public class GetUsersQueryHendler : IRequestHandler<GetUsersQuery, List<IdentityUser>>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<GetUsersQueryHendler> _logger;

        public GetUsersQueryHendler(UserManager<IdentityUser> userManager, ILogger<GetUsersQueryHendler> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<List<IdentityUser>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
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
