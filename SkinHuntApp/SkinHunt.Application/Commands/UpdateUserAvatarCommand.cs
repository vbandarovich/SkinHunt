using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SkinHunt.Application.Common.Interfaces;
using SkinHunt.Application.Common.Models;

namespace SkinHunt.Application.Commands;

public class UpdateUserAvatarCommand : IRequest<UserDto>
{
    public UpdateUserAvatarModel Model { get; set; }
    
    public UpdateUserAvatarCommand(UpdateUserAvatarModel model)
    {
        Model = model;
    }
}

public class UpdateUserAvatarCommandHandler : IRequestHandler<UpdateUserAvatarCommand, UserDto>
{
    private readonly DbContext _dbContext;
    private readonly IJwtExtension _jwtExtension;
    private readonly IMapper _mapper;

    public UpdateUserAvatarCommandHandler(DbContext dbContext, IJwtExtension jwtExtension, IMapper mapper)
    {
        _dbContext = dbContext;
        _jwtExtension = jwtExtension;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(UpdateUserAvatarCommand request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.FirstAsync(o => o.Id == request.Model.UserId, cancellationToken);

        user.Avatar = request.Model.Avatar;

        await _dbContext.SaveChangesAsync(cancellationToken);
        
        var token = await _jwtExtension.GenerateTokenAsync(user);

        var userDto = await _dbContext.Users
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .FirstAsync(o => o.Id == request.Model.UserId);

        userDto.Token = token;

        return userDto;
    }
}