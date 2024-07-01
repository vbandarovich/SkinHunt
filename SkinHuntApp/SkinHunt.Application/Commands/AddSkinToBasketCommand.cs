using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkinHunt.Application.Common.Entities;

namespace SkinHunt.Application.Commands
{
    public class AddSkinToBasketCommand : IRequest
    {
        public string User { get; set; }
        
        public string Skin { get; set; }

        public AddSkinToBasketCommand(string user, string skin)
        {
            User = user;
            Skin = skin;
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
            var user = await _dbContext.Users.FirstAsync(o => o.Id == request.User);
            var skin = await _dbContext.Skins.FirstAsync(o => o.Id.ToString() == request.Skin);
            
            var entity = new BasketEntity()
            {
                User = user,
                Skin = skin,
                CreatedDate = DateTime.UtcNow
            };

            await _dbContext.Basket.AddAsync(entity, cancellationToken);

            _logger.LogInformation("Skin added to basket successfully.");

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
