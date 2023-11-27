using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SkinHunt.Application.Common.Entities;

namespace SkinHunt.Application.Commands
{
    public class RemoveSkinFromBasketCommand : IRequest
    {
        public BasketEntity Skin { get; set; }

        public RemoveSkinFromBasketCommand(BasketEntity skin)
        {
            Skin = skin;
        }
    }

    public class RemoveSkinFromBasketCommandHandler : IRequestHandler<RemoveSkinFromBasketCommand>
    {
        private readonly DbContext _dbContext;
        private readonly ILogger<RemoveSkinFromBasketCommandHandler> _logger;

        public RemoveSkinFromBasketCommandHandler(DbContext dbContext, ILogger<RemoveSkinFromBasketCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task Handle(RemoveSkinFromBasketCommand request, CancellationToken cancellationToken)
        {
            _dbContext.Basket.Remove(request.Skin);

            _logger.LogInformation("Skin removed from basket successfully.");

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
