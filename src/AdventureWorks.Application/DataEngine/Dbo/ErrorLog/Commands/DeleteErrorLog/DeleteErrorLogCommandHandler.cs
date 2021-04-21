using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Dbo;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Dbo.ErrorLog.Commands.DeleteErrorLog
{
    public partial class DeleteErrorLogCommandHandler : IRequestHandler<DeleteErrorLogCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private ErrorLogsQueryManager _queryManager;

        public DeleteErrorLogCommandHandler(IAdventureWorksContext context, IMediator mediator, ErrorLogsQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteErrorLogCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ErrorLogs
                .FirstOrDefaultAsync(c => c.ErrorLogID == request.ErrorLogID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.ErrorLog), JsonConvert.SerializeObject(new { request.ErrorLogID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new ErrorLogDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
