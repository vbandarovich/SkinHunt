using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkinHunt.Application.Common.Entities;

namespace SkinHunt.Application.Queries
{
    public class GetSkinsQuery : IRequest<List<SkinEntity>>
    {
    }

    public class GetSkinsQueryHandler : IRequestHandler<GetSkinsQuery, List<SkinEntity>>
    {
        private readonly DbContext _db;
        private readonly ILogger<GetSkinsQueryHandler> _logger;

        public GetSkinsQueryHandler(DbContext db, ILogger<GetSkinsQueryHandler> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<List<SkinEntity>> Handle(GetSkinsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _db.Skins.ToListAsync();

                if (result.Any())
                {
                    _logger.LogInformation("Skins retrieved successfully.");
                    return result;
                }

                return new List<SkinEntity>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving skins.");
                return new List<SkinEntity>();
            }
        }
    }
}
