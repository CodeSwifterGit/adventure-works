using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Production.ScrapReason.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ScrapReason.Commands.DeleteScrapReason
{
    public partial class DeleteScrapReasonCommandHandler : IRequestHandler<DeleteScrapReasonCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private ScrapReasonsQueryManager _queryManager;

        public DeleteScrapReasonCommandHandler(IAdventureWorksContext context, IMediator mediator, ScrapReasonsQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteScrapReasonCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ScrapReasons
                .FirstOrDefaultAsync(c => c.ScrapReasonID == request.ScrapReasonID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.ScrapReason), JsonConvert.SerializeObject(new { request.ScrapReasonID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new ScrapReasonDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
