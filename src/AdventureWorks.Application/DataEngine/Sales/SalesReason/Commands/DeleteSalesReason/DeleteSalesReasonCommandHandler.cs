using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Sales.SalesReason.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesReason.Commands.DeleteSalesReason
{
    public partial class DeleteSalesReasonCommandHandler : IRequestHandler<DeleteSalesReasonCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private SalesReasonsQueryManager _queryManager;

        public DeleteSalesReasonCommandHandler(IAdventureWorksContext context, IMediator mediator, SalesReasonsQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteSalesReasonCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SalesReasons
                .FirstOrDefaultAsync(c => c.SalesReasonID == request.SalesReasonID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.SalesReason), JsonConvert.SerializeObject(new { request.SalesReasonID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new SalesReasonDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
