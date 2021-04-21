using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeaderSalesReason.Commands.DeleteSalesOrderHeaderSalesReason
{
    public partial class DeleteSalesOrderHeaderSalesReasonCommandHandler : IRequestHandler<DeleteSalesOrderHeaderSalesReasonCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private SalesOrderHeaderSalesReasonsQueryManager _queryManager;

        public DeleteSalesOrderHeaderSalesReasonCommandHandler(IAdventureWorksContext context, IMediator mediator, SalesOrderHeaderSalesReasonsQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteSalesOrderHeaderSalesReasonCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SalesOrderHeaderSalesReasons
                .FirstOrDefaultAsync(c => c.SalesOrderID == request.SalesOrderID && c.SalesReasonID == request.SalesReasonID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.SalesOrderHeaderSalesReason), JsonConvert.SerializeObject(new { request.SalesOrderID, request.SalesReasonID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new SalesOrderHeaderSalesReasonDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
