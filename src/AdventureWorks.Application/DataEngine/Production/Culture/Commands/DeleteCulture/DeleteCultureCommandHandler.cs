using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Production.Culture.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.Culture.Commands.DeleteCulture
{
    public partial class DeleteCultureCommandHandler : IRequestHandler<DeleteCultureCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private CulturesQueryManager _queryManager;

        public DeleteCultureCommandHandler(IAdventureWorksContext context, IMediator mediator, CulturesQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteCultureCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Cultures
                .FirstOrDefaultAsync(c => c.CultureID == request.CultureID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.Culture), JsonConvert.SerializeObject(new { request.CultureID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new CultureDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
