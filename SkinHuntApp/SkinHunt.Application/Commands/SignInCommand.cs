using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SkinHunt.Application.Common.Interfaces;
using SkinHunt.Domain.Models;

namespace SkinHunt.Application.Commands
{
    public class SignInCommand : IRequest<object>
    {
        public readonly SignInModel model;

        public SignInCommand(SignInModel signInModel) 
        {  
            model = signInModel; 
        }
    }

    public class SignInCommandHandler : IRequestHandler<SignInCommand, object>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<SignInCommandHandler> _logger;
        private readonly IJwtExtension _jwtExtension;

        public SignInCommandHandler(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            ILogger<SignInCommandHandler> logger, IJwtExtension jwtExtension)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _jwtExtension = jwtExtension;
        }

        public async Task<object> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.model.Email);

                if (user is not null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user.UserName, request.model.Password, false, true);

                    if (result.Succeeded)
                    {
                        _logger.LogInformation("Login successeded.");

                        var token = await _jwtExtension.GenerateTokenAsync(user);

                        return token;
                    }

                    _logger.LogError("Login failed: password was incorrect.");
                    return null;
                }

                _logger.LogError("Login failed: user not found.");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Login failed with exception: {ex.Message}");
                return null;
            }
        }
    }
}
