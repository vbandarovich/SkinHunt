using MediatR;

namespace SkinHunt.Application.Commands
{
    public class GetAdminRoleCommand : IRequest<object>
    {
    }

    public class GetAdminRoleCommandHandler : IRequestHandler<GetAdminRoleCommand, object> 
    {
        public async Task<object> Handle(GetAdminRoleCommand request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
