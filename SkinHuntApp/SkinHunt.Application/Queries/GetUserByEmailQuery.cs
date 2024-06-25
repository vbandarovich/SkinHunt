using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SkinHunt.Application.Common.Models;

namespace SkinHunt.Application.Queries
{
    public class GetUserByEmailQuery : IRequest<UserDto>
    {
        public string Email { get; set; }

        public GetUserByEmailQuery(string email)
        {
            Email = email;
        }
    }

    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserDto>
    {
        private readonly DbContext _dbContext;
        private readonly IMapper _mapper;
        
        public GetUserByEmailQueryHandler(DbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Users
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .FirstAsync(o => o.Email == request.Email);
        }
    }
}
