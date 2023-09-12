using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkinHunt.Application.Common.Entities;

namespace SkinHunt.Application.Commands
{
    public class GetSkinsCommand : IRequest<List<SkinEntity>>
    {
    }

    public class GetSkinsCommandHandler : IRequestHandler<GetSkinsCommand, List<SkinEntity>>
    {
        private readonly DbContext _db;
        private readonly ILogger<GetSkinsCommandHandler> _logger;

        public GetSkinsCommandHandler(DbContext db, ILogger<GetSkinsCommandHandler> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<List<SkinEntity>> Handle(GetSkinsCommand request, CancellationToken cancellationToken)
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
