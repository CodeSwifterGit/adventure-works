using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Commands.DeleteSalesTaxRate
{
    public partial class DeleteSalesTaxRateCommandHandler : IRequestHandler<DeleteSalesTaxRateCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private SalesTaxRatesQueryManager _queryManager;

        public DeleteSalesTaxRateCommandHandler(IAdventureWorksContext context, IMediator mediator, SalesTaxRatesQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteSalesTaxRateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SalesTaxRates
                .FirstOrDefaultAsync(c => c.SalesTaxRateID == request.SalesTaxRateID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.SalesTaxRate), JsonConvert.SerializeObject(new { request.SalesTaxRateID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new SalesTaxRateDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
