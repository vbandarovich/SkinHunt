using MediatR;
using Microsoft.EntityFrameworkCore;
using SkinHunt.Application.Common.Entities;

namespace SkinHunt.Application.Queries
{
    public class GetSkinByIdFromBasketQuery : IRequest<BasketEntity>
    {
        public string UserId { get; set; }

        public Guid SkinId { get; set; }

        public GetSkinByIdFromBasketQuery(string userId, Guid skinId)
        {
            UserId = userId;
            SkinId = skinId;
        }
    }

    public class GetSkinByIdFromBasketQueryHandler : IRequestHandler<GetSkinByIdFromBasketQuery, BasketEntity>
    {
        private readonly DbContext _dbContext;

        public GetSkinByIdFromBasketQueryHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BasketEntity> Handle(GetSkinByIdFromBasketQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Basket.FirstOrDefaultAsync(x => x.User.Id == request.UserId && x.Skin.Id == request.SkinId);
        }
    }
}
