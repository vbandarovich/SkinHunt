using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SkinHunt.Application.Common.Entities;
using SkinHunt.Application.Common.Models;

namespace SkinHunt.Application.Commands
{
    public class AddSkinDbCommand : IRequest<bool>
    {
        public SkinModel Model { get; set; }

        public AddSkinDbCommand(SkinModel model)
        {
            Model = model;
        }
    }

    public class AddSkinDbCommandHandler : IRequestHandler<AddSkinDbCommand, bool>
    {
        private readonly DbContext _db;
        private readonly ILogger<AddSkinDbCommandHandler> _logger;
        private readonly IMapper _mapper;

        public AddSkinDbCommandHandler(DbContext db, ILogger<AddSkinDbCommandHandler> logger, IMapper mapper) 
        {
            _db = db;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<bool> Handle(AddSkinDbCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var model = _mapper.Map<SkinEntity>(request.Model);

                _db.Skins.Add(model);

                await _db.SaveChangesAsync(cancellationToken);

                _logger.LogInformation("Skin added successfully.");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred: {ex.Message}.");
                return false;
            }
        }
    }
}
