using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SkinHunt.Application.Common.Entities;

namespace SkinHunt.Application.Commands
{
    public class InitSkinsCommand : IRequest
    {
    }

    public class InitSkinsCommandHandler : IRequestHandler<InitSkinsCommand>
    {
        private readonly DbContext _db;
        private readonly ILogger<InitSkinsCommandHandler> _logger;
        private readonly string SkinsFileName = "Skins.json";

        public InitSkinsCommandHandler(DbContext db, ILogger<InitSkinsCommandHandler> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task Handle(InitSkinsCommand request, CancellationToken cancellationToken)
        {
            await _db.Database.EnsureCreatedAsync(cancellationToken);

            if (!_db.Skins.Any())
            {
                try
                {
                    using var reader = new StreamReader(SkinsFileName);

                    var json = reader.ReadToEnd();

                    var skins = JsonConvert.DeserializeObject<List<SkinEntity>>(json);

                    if (skins is not null)
                    {
                        await _db.Skins.AddRangeAsync(skins, cancellationToken);

                        await _db.SaveChangesAsync(cancellationToken);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Init database by skins failed. Message: {ex.Message}");
                }
                
            }
        }
    }
}
