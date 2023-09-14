using MediatR;
using Microsoft.AspNetCore.Identity;

namespace SkinHunt.Application.Queries
{
    public class GetUserByEmailQuery : IRequest<IdentityUser>
    {
        public string Email { get; set; }

        public GetUserByEmailQuery(string email)
        {
            Email = email;
        }
    }

    public class GetUserByEmailQueryHanlder : IRequestHandler<GetUserByEmailQuery, IdentityUser>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public GetUserByEmailQueryHanlder(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityUser> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            return await _userManager.FindByEmailAsync(request.Email);
        }
    }
}
