using MediatR;
using Microsoft.AspNetCore.Identity;
using SkinHunt.Application.Common.Interfaces;
using SkinHunt.Domain.Constants;
using SkinHunt.Domain.Models;

namespace SkinHunt.Application.Commands
{
    public class SignUpCommand : IRequest<object>
    {
        public SignUpModel Model { get; set; }

        public SignUpCommand(SignUpModel model)
        {
            Model = model;
        }
    }

    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, object>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IJwtExtension _jwtExtension;

        public SignUpCommandHandler(UserManager<IdentityUser> userManager, IJwtExtension jwtExtension)
        {
            _userManager = userManager;
            _jwtExtension = jwtExtension;
        }

        public async Task<object> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            var user = new IdentityUser
            {
                UserName = request.Model.Username,
                Email = request.Model.Email,
                PhoneNumber = request.Model.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, request.Model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, RolesConstants.User);

                return await _jwtExtension.GenerateTokenAsync(user);
            }

            return null;
        }
    }
}
