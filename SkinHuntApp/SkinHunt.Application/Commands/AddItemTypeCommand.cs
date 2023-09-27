using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkinHunt.Application.Common.Entities;
using SkinHunt.Application.Common.Models;

namespace SkinHunt.Application.Commands
{
    public class AddItemTypeCommand : IRequest<ItemTypeEntity>
    {
        public ItemTypeModel ItemType { get; set; }

        public AddItemTypeCommand(ItemTypeModel model)
        {
            ItemType = model;
        }
    }

    public class AddItemTypeCommandHandler : IRequestHandler<AddItemTypeCommand, ItemTypeEntity>
    {
        private readonly DbContext _db;
        private readonly ILogger<AddItemTypeCommandHandler> _logger;
        private readonly IMapper _mapper;

        public AddItemTypeCommandHandler(DbContext db, ILogger<AddItemTypeCommandHandler> logger, IMapper mapper)
        {
            _db = db;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ItemTypeEntity> Handle(AddItemTypeCommand request, CancellationToken cancellationToken)
        {
            if (!_db.SkinTypes.Any(x => x.Category.Equals(request.ItemType.Category) && x.Subcategory.Equals(request.ItemType.Subcategory)))
            {
                var entity = _mapper.Map<ItemTypeEntity>(request.ItemType);

                await _db.SkinTypes.AddAsync(entity, cancellationToken);

                _logger.LogInformation($"Added new item type. Category name: {entity.Category}. Subcategory name: {entity.Subcategory}");

                await _db.SaveChangesAsync(cancellationToken);
            }

            return await _db.SkinTypes.FirstAsync(x => x.Category.Equals(request.ItemType.Category)
                && x.Subcategory.Equals(request.ItemType.Subcategory), cancellationToken);
        }
    }
}
