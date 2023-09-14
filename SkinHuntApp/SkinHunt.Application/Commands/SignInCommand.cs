using MediatR;
using Microsoft.AspNetCore.Identity;
using SkinHunt.Application.Common.Interfaces;

namespace SkinHunt.Application.Commands
{
    public class SignInCommand : IRequest<object>
    {
        public IdentityUser User { get; set; }
        public string Password { get; set; }

        public SignInCommand(IdentityUser user, string password)
        {
            User = user;
            Password = password;
        }
    }

    public class SignInCommandHandler : IRequestHandler<SignInCommand, object>
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IJwtExtension _jwtExtension;

        public SignInCommandHandler(SignInManager<IdentityUser> signInManager, IJwtExtension jwtExtension)
        {
            _signInManager = signInManager;
            _jwtExtension = jwtExtension;
        }

        public async Task<object> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(request.User.UserName, request.Password, false, true);

            if (result.Succeeded)
            {
                var token = await _jwtExtension.GenerateTokenAsync(request.User);

                return token;
            }

            return null;
        }
    }
}
