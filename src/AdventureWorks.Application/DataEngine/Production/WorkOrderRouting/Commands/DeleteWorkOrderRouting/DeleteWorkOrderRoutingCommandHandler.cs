using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Commands.DeleteWorkOrderRouting
{
    public partial class DeleteWorkOrderRoutingCommandHandler : IRequestHandler<DeleteWorkOrderRoutingCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private WorkOrderRoutingsQueryManager _queryManager;

        public DeleteWorkOrderRoutingCommandHandler(IAdventureWorksContext context, IMediator mediator, WorkOrderRoutingsQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteWorkOrderRoutingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.WorkOrderRoutings
                .FirstOrDefaultAsync(c => c.WorkOrderID == request.WorkOrderID && c.ProductID == request.ProductID && c.OperationSequence == request.OperationSequence, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.WorkOrderRouting), JsonConvert.SerializeObject(new { request.WorkOrderID, request.ProductID, request.OperationSequence }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new WorkOrderRoutingDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
