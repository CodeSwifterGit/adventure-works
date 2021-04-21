using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Production.Illustration.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.Illustration.Commands.DeleteIllustration
{
    public partial class DeleteIllustrationCommandHandler : IRequestHandler<DeleteIllustrationCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private IllustrationsQueryManager _queryManager;

        public DeleteIllustrationCommandHandler(IAdventureWorksContext context, IMediator mediator, IllustrationsQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteIllustrationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Illustrations
                .FirstOrDefaultAsync(c => c.IllustrationID == request.IllustrationID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.Illustration), JsonConvert.SerializeObject(new { request.IllustrationID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new IllustrationDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
