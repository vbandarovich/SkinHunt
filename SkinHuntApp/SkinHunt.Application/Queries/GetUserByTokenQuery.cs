using MediatR;
using Microsoft.AspNetCore.Identity;

namespace SkinHunt.Application.Queries
{
    public class GetUserByTokenQuery : IRequest<IdentityUser>
    {
        public string Id { get; set; }

        public GetUserByTokenQuery(string id)
        {
            Id = id;
        }
    }

    public class GetUserByTokenQueryHandler : IRequestHandler<GetUserByTokenQuery, IdentityUser>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public GetUserByTokenQueryHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityUser> Handle(GetUserByTokenQuery request, CancellationToken cancellationToken)
        {
            return await _userManager.FindByIdAsync(request.Id);
        }
    }
}
