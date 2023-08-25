using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace SkinHunt.Application.Commands
{
    public class InitAdminUserCommand : IRequest
    {
    }

    public class InitAdminUserCommandHandler : IRequestHandler<InitAdminUserCommand>
    {
        private readonly DbContext _db;
        private readonly ILogger<InitRolesCommandHandler> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public InitAdminUserCommandHandler(DbContext db, ILogger<InitRolesCommandHandler> logger,
            UserManager<IdentityUser> userManager)
        {
            _db = db;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task Handle(InitAdminUserCommand request, CancellationToken cancellationToken)
        {
            if (!_db.Users.Any())
            {
                var admin = new IdentityUser
                {
                    UserName = "admin",
                    Email = "admin@gmail.com",
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(admin, "s0meTh1ngHard#");

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(admin, "admin");

                    _logger.LogInformation("Added default admin user to database.");
                }               
            }
        }
    }
}
