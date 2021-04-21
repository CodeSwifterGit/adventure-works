using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Queries.GetProductCostHistories;
using AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Commands.UpdateProductCostHistory
{
    public partial class UpdateProductCostHistoryCommandHandler : IRequestHandler<UpdateProductCostHistoryCommand, ProductCostHistoryLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly ProductCostHistoriesQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateProductCostHistoryCommandHandler(IAdventureWorksContext context,
            ProductCostHistoriesQueryManager queryManager,
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

        public async Task<ProductCostHistoryLookupModel> Handle(UpdateProductCostHistoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductCostHistories
                .SingleAsync(c => c.ProductID == request.RequestTarget.ProductID && c.StartDate == request.RequestTarget.StartDate, cancellationToken);
            var oldEntity = _mapper.Map<Entities.ProductCostHistory, UpdateProductCostHistoryCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductCostHistory), JsonConvert.SerializeObject(new { request.RequestTarget.ProductID, request.RequestTarget.StartDate }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.ProductCostHistories.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.ProductCostHistories.SingleAsync(c => c.ProductID == request.RequestTarget.ProductID && c.StartDate == request.RequestTarget.StartDate, cancellationToken);

            await _mediator.Publish(new ProductCostHistoryUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.ProductCostHistory, ProductCostHistoryLookupModel>(entity);
        }
    }
}
