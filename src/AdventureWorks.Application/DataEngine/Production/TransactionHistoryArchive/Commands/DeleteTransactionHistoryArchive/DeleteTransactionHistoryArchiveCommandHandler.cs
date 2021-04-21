using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Production.TransactionHistoryArchive.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.TransactionHistoryArchive.Commands.DeleteTransactionHistoryArchive
{
    public partial class DeleteTransactionHistoryArchiveCommandHandler : IRequestHandler<DeleteTransactionHistoryArchiveCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private TransactionHistoryArchivesQueryManager _queryManager;

        public DeleteTransactionHistoryArchiveCommandHandler(IAdventureWorksContext context, IMediator mediator, TransactionHistoryArchivesQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteTransactionHistoryArchiveCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TransactionHistoryArchives
                .FirstOrDefaultAsync(c => c.TransactionID == request.TransactionID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.TransactionHistoryArchive), JsonConvert.SerializeObject(new { request.TransactionID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new TransactionHistoryArchiveDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
