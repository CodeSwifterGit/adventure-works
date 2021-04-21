using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Commands.DeleteSalesOrderDetail
{
    public partial class DeleteSalesOrderDetailCommandHandler : IRequestHandler<DeleteSalesOrderDetailCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private SalesOrderDetailsQueryManager _queryManager;

        public DeleteSalesOrderDetailCommandHandler(IAdventureWorksContext context, IMediator mediator, SalesOrderDetailsQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteSalesOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SalesOrderDetails
                .FirstOrDefaultAsync(c => c.SalesOrderID == request.SalesOrderID && c.SalesOrderDetailID == request.SalesOrderDetailID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.SalesOrderDetail), JsonConvert.SerializeObject(new { request.SalesOrderID, request.SalesOrderDetailID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new SalesOrderDetailDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
