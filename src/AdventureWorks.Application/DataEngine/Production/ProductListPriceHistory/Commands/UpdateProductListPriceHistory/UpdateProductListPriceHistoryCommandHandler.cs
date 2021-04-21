using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Queries.GetProductListPriceHistories;
using AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Commands.UpdateProductListPriceHistory
{
    public partial class UpdateProductListPriceHistoryCommandHandler : IRequestHandler<UpdateProductListPriceHistoryCommand, ProductListPriceHistoryLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly ProductListPriceHistoriesQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateProductListPriceHistoryCommandHandler(IAdventureWorksContext context,
            ProductListPriceHistoriesQueryManager queryManager,
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

        public async Task<ProductListPriceHistoryLookupModel> Handle(UpdateProductListPriceHistoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductListPriceHistories
                .SingleAsync(c => c.ProductID == request.RequestTarget.ProductID && c.StartDate == request.RequestTarget.StartDate, cancellationToken);
            var oldEntity = _mapper.Map<Entities.ProductListPriceHistory, UpdateProductListPriceHistoryCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductListPriceHistory), JsonConvert.SerializeObject(new { request.RequestTarget.ProductID, request.RequestTarget.StartDate }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.ProductListPriceHistories.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.ProductListPriceHistories.SingleAsync(c => c.ProductID == request.RequestTarget.ProductID && c.StartDate == request.RequestTarget.StartDate, cancellationToken);

            await _mediator.Publish(new ProductListPriceHistoryUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.ProductListPriceHistory, ProductListPriceHistoryLookupModel>(entity);
        }
    }
}
