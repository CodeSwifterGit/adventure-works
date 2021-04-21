using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Dbo;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Dbo.DatabaseLog.Commands.DeleteDatabaseLog
{
    public partial class DeleteDatabaseLogCommandHandler : IRequestHandler<DeleteDatabaseLogCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private DatabaseLogsQueryManager _queryManager;

        public DeleteDatabaseLogCommandHandler(IAdventureWorksContext context, IMediator mediator, DatabaseLogsQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteDatabaseLogCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.DatabaseLogs
                .FirstOrDefaultAsync(c => c.DatabaseLogID == request.DatabaseLogID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.DatabaseLog), JsonConvert.SerializeObject(new { request.DatabaseLogID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new DatabaseLogDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
