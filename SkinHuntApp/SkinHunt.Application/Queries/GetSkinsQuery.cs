using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkinHunt.Application.Common.Models;

namespace SkinHunt.Application.Queries
{
    public class GetSkinsQuery : IRequest<List<SkinDto>>
    {
    }

    public class GetSkinsQueryHandler : IRequestHandler<GetSkinsQuery, List<SkinDto>>
    {
        private readonly DbContext _db;
        private readonly ILogger<GetSkinsQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetSkinsQueryHandler(DbContext db, ILogger<GetSkinsQueryHandler> logger, IMapper mapper)
        {
            _db = db;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<SkinDto>> Handle(GetSkinsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _db.Skins
                    .Include(s => s.Type)
                    .ProjectTo<SkinDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                if (result.Any())
                {
                    _logger.LogInformation("Skins retrieved successfully.");
                    return result;
                }

                return new List<SkinDto>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving skins.");
                return new List<SkinDto>();
            }
        }
    }
}
