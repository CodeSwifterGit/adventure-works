using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Sales.SalesPerson.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesPerson.Commands.DeleteSalesPerson
{
    public partial class DeleteSalesPersonCommandHandler : IRequestHandler<DeleteSalesPersonCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private SalesPeopleQueryManager _queryManager;

        public DeleteSalesPersonCommandHandler(IAdventureWorksContext context, IMediator mediator, SalesPeopleQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteSalesPersonCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SalesPeople
                .FirstOrDefaultAsync(c => c.SalesPersonID == request.SalesPersonID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.SalesPerson), JsonConvert.SerializeObject(new { request.SalesPersonID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new SalesPersonDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
