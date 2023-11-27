using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkinHunt.Application.Common.Entities;

namespace SkinHunt.Application.Queries
{
    public class GetSkinsByUserIdFromBasketQuery : IRequest<List<BasketEntity>>
    {
        public string Id { get; set; }

        public GetSkinsByUserIdFromBasketQuery(string id)
        {
            Id = id;
        }
    }

    public class GetSkinsByUserIdQueryHandler : IRequestHandler<GetSkinsByUserIdFromBasketQuery, List<BasketEntity>>
    {
        private readonly DbContext _db;
        private readonly ILogger<GetSkinsByUserIdQueryHandler> _logger;

        public GetSkinsByUserIdQueryHandler(DbContext db, ILogger<GetSkinsByUserIdQueryHandler> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<List<BasketEntity>> Handle(GetSkinsByUserIdFromBasketQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _db.Basket.Where(x => x.User.Id == request.Id)
                    .Include(x => x.User)
                    .Include(x => x.Skin)
                    .ToListAsync(cancellationToken);

                if (result.Any())
                {
                    _logger.LogInformation("Skins retrieved successfully.");
                    return result;
                }

                return new List<BasketEntity>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving skins.");
                return new List<BasketEntity>();
            }
        }
    }
}
