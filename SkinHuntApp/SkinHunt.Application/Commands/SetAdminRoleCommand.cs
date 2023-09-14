using MediatR;

namespace SkinHunt.Application.Commands
{
    public class SetAdminRoleCommand : IRequest<object>
    {
    }

    public class SetAdminRoleCommandHandler : IRequestHandler<SetAdminRoleCommand, object>
    {
        public async Task<object> Handle(SetAdminRoleCommand request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
