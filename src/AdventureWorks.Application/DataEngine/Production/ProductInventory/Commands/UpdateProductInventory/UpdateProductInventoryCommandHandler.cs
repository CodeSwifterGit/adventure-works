using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductInventory.Queries.GetProductInventories;
using AdventureWorks.Application.DataEngine.Production.ProductInventory.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ProductInventory.Commands.UpdateProductInventory
{
    public partial class UpdateProductInventoryCommandHandler : IRequestHandler<UpdateProductInventoryCommand, ProductInventoryLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly ProductInventoriesQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateProductInventoryCommandHandler(IAdventureWorksContext context,
            ProductInventoriesQueryManager queryManager,
            IAuthenticatedUserService authenticatedUserService,
            IMediator mediator,
            IMapper mapper,
            IDateTime machineDateTime)
        {
            _context = context;
            _queryManager = queryManager;
            _authenticatedUserService = authenticatedUserService;
            _mediator = mediator;
            _mapper = mapper;
            _machineDateTime = machineDateTime;
        }

        public async Task<ProductInventoryLookupModel> Handle(UpdateProductInventoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductInventories
                .SingleAsync(c => c.ProductID == request.RequestTarget.ProductID && c.LocationID == request.RequestTarget.LocationID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.ProductInventory, UpdateProductInventoryCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductInventory), JsonConvert.SerializeObject(new { request.RequestTarget.ProductID, request.RequestTarget.LocationID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.ProductInventories.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.ProductInventories.SingleAsync(c => c.ProductID == request.RequestTarget.ProductID && c.LocationID == request.RequestTarget.LocationID, cancellationToken);

            await _mediator.Publish(new ProductInventoryUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.ProductInventory, ProductInventoryLookupModel>(entity);
        }
    }
}
