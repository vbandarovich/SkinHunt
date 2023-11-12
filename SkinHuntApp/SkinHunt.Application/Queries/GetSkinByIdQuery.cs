using MediatR;
using Microsoft.EntityFrameworkCore;
using SkinHunt.Application.Common.Entities;

namespace SkinHunt.Application.Queries
{
    public class GetSkinByIdQuery : IRequest<SkinEntity>
    {
        public Guid Id { get; set; }

        public GetSkinByIdQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetSkinByIdQueryHandler : IRequestHandler<GetSkinByIdQuery, SkinEntity>
    {
        private readonly DbContext _dbContext;

        public GetSkinByIdQueryHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SkinEntity> Handle(GetSkinByIdQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Skins.FirstAsync(x => x.Id == request.Id);
        }
    }
}
