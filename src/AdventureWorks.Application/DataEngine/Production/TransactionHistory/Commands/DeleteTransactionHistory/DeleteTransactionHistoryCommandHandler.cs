using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Production.TransactionHistory.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.TransactionHistory.Commands.DeleteTransactionHistory
{
    public partial class DeleteTransactionHistoryCommandHandler : IRequestHandler<DeleteTransactionHistoryCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private TransactionHistoriesQueryManager _queryManager;

        public DeleteTransactionHistoryCommandHandler(IAdventureWorksContext context, IMediator mediator, TransactionHistoriesQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteTransactionHistoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TransactionHistories
                .FirstOrDefaultAsync(c => c.TransactionID == request.TransactionID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.TransactionHistory), JsonConvert.SerializeObject(new { request.TransactionID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new TransactionHistoryDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
