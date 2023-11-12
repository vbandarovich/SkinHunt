using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SkinHunt.Application.Common.Entities;
using SkinHunt.Application.Common.Models;

namespace SkinHunt.Application.Commands
{
    public class AddSkinToBasketCommand : IRequest
    {
        public BasketModel Model { get; set; }

        public AddSkinToBasketCommand(BasketModel model)
        {
            Model = model;
        }
    }

    public class AddSkinToBasketCommandHandler : IRequestHandler<AddSkinToBasketCommand>
    {
        private readonly DbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<AddSkinToBasketCommandHandler> _logger;

        public AddSkinToBasketCommandHandler(DbContext dbContext, IMapper mapper, ILogger<AddSkinToBasketCommandHandler> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(AddSkinToBasketCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<BasketEntity>(request.Model);

            await _dbContext.Basket.AddAsync(entity, cancellationToken);

            _logger.LogInformation("Skin added to basket successfully.");

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
