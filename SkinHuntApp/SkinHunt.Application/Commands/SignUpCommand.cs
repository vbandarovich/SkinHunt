using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SkinHunt.Application.Common.Interfaces;
using SkinHunt.Domain.Constants;
using SkinHunt.Domain.Models;

namespace SkinHunt.Application.Commands
{
    public class SignUpCommand : IRequest<object>
    {
        public readonly SignUpModel model;

        public SignUpCommand(SignUpModel signUpModel) 
        {
            model = signUpModel;
        }
    }

    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, object>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<SignUpCommandHandler> _logger;
        private readonly IJwtExtension _jwtExtension;

        public SignUpCommandHandler(UserManager<IdentityUser> userManager, ILogger<SignUpCommandHandler> logger, IJwtExtension jwtExtension)
        {
            _userManager = userManager;
            _logger = logger;
            _jwtExtension = jwtExtension;
        }

        public async Task<object> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = new IdentityUser
                {
                    UserName = request.model.Username,
                    Email = request.model.Email,
                    PhoneNumber = request.model.PhoneNumber
                };

                var result = await _userManager.CreateAsync(user, request.model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, RolesConstants.User);

                    _logger.LogInformation("User has been created.");

                    var token = await _jwtExtension.GenerateTokenAsync(user);

                    return token;
                }

                _logger.LogInformation($"User not created. Errors: {result.Errors.First()}.");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Sign in failed with exception: {ex.Message}.");
                return null;
            }
        }
    }
}
