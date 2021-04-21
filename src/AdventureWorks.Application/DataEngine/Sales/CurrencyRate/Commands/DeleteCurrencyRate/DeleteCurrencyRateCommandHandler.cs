using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Commands.DeleteCurrencyRate
{
    public partial class DeleteCurrencyRateCommandHandler : IRequestHandler<DeleteCurrencyRateCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private CurrencyRatesQueryManager _queryManager;

        public DeleteCurrencyRateCommandHandler(IAdventureWorksContext context, IMediator mediator, CurrencyRatesQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteCurrencyRateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.CurrencyRates
                .FirstOrDefaultAsync(c => c.CurrencyRateID == request.CurrencyRateID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.CurrencyRate), JsonConvert.SerializeObject(new { request.CurrencyRateID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new CurrencyRateDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
