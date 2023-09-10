using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkinHunt.Application.Common.Entities;
using SkinHunt.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkinHunt.Application.Commands
{
    public class GetSkinsCommand : IRequest<object>
    {
    }

    public class GetSkinsCommandHandler : IRequestHandler<GetSkinsCommand, object>
    {
        private readonly DbContext _db;
        private readonly ILogger<GetSkinsCommandHandler> _logger;

        public GetSkinsCommandHandler(DbContext db, ILogger<GetSkinsCommandHandler> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<object> Handle(GetSkinsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _db.Skins.ToListAsync();

                if (result.Any())
                {
                    _logger.LogInformation("Skins retrieved successfully.");
                    return result;
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving skins.");
                return null;
            }
        }
    }
}
