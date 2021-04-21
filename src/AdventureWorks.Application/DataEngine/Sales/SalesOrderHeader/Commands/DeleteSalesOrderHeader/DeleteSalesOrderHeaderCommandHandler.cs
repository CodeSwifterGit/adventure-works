using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderHeader.Commands.DeleteSalesOrderHeader
{
    public partial class DeleteSalesOrderHeaderCommandHandler : IRequestHandler<DeleteSalesOrderHeaderCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private SalesOrderHeadersQueryManager _queryManager;

        public DeleteSalesOrderHeaderCommandHandler(IAdventureWorksContext context, IMediator mediator, SalesOrderHeadersQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteSalesOrderHeaderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SalesOrderHeaders
                .FirstOrDefaultAsync(c => c.SalesOrderID == request.SalesOrderID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.SalesOrderHeader), JsonConvert.SerializeObject(new { request.SalesOrderID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new SalesOrderHeaderDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
