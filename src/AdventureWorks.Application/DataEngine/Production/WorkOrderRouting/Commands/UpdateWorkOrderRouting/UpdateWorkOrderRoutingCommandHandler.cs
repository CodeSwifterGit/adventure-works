using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Queries.GetWorkOrderRoutings;
using AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Commands.UpdateWorkOrderRouting
{
    public partial class UpdateWorkOrderRoutingCommandHandler : IRequestHandler<UpdateWorkOrderRoutingCommand, WorkOrderRoutingLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly WorkOrderRoutingsQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateWorkOrderRoutingCommandHandler(IAdventureWorksContext context,
            WorkOrderRoutingsQueryManager queryManager,
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

        public async Task<WorkOrderRoutingLookupModel> Handle(UpdateWorkOrderRoutingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.WorkOrderRoutings
                .SingleAsync(c => c.WorkOrderID == request.RequestTarget.WorkOrderID && c.ProductID == request.RequestTarget.ProductID && c.OperationSequence == request.RequestTarget.OperationSequence, cancellationToken);
            var oldEntity = _mapper.Map<Entities.WorkOrderRouting, UpdateWorkOrderRoutingCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(WorkOrderRouting), JsonConvert.SerializeObject(new { request.RequestTarget.WorkOrderID, request.RequestTarget.ProductID, request.RequestTarget.OperationSequence }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.WorkOrderRoutings.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.WorkOrderRoutings.SingleAsync(c => c.WorkOrderID == request.RequestTarget.WorkOrderID && c.ProductID == request.RequestTarget.ProductID && c.OperationSequence == request.RequestTarget.OperationSequence, cancellationToken);

            await _mediator.Publish(new WorkOrderRoutingUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.WorkOrderRouting, WorkOrderRoutingLookupModel>(entity);
        }
    }
}
