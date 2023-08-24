using MediatR;
using SkinHunt.Application.Commands;
using SkinHunt.Application.Common.Interfaces;

namespace SkinHunt.Application.Services
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IMediator _mediator;
        
        public DbInitializer(IMediator mediator)
        {         
            _mediator = mediator;
        }

        public async Task InitializeAsync()
        {
            await _mediator.Send(new InitSkinsDbCommand());
        }
    }
}
