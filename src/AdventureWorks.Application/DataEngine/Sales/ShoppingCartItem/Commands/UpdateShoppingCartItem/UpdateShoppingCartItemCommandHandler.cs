using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Queries.GetShoppingCartItems;
using AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Commands.UpdateShoppingCartItem
{
    public partial class UpdateShoppingCartItemCommandHandler : IRequestHandler<UpdateShoppingCartItemCommand, ShoppingCartItemLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly ShoppingCartItemsQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateShoppingCartItemCommandHandler(IAdventureWorksContext context,
            ShoppingCartItemsQueryManager queryManager,
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

        public async Task<ShoppingCartItemLookupModel> Handle(UpdateShoppingCartItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ShoppingCartItems
                .SingleAsync(c => c.ShoppingCartItemID == request.RequestTarget.ShoppingCartItemID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.ShoppingCartItem, UpdateShoppingCartItemCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ShoppingCartItem), JsonConvert.SerializeObject(new { request.RequestTarget.ShoppingCartItemID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.ShoppingCartItems.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.ShoppingCartItems.SingleAsync(c => c.ShoppingCartItemID == request.RequestTarget.ShoppingCartItemID, cancellationToken);

            await _mediator.Publish(new ShoppingCartItemUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.ShoppingCartItem, ShoppingCartItemLookupModel>(entity);
        }
    }
}
