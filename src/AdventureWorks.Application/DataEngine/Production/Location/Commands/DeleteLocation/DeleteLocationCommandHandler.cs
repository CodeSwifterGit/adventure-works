using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Production.Location.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.Location.Commands.DeleteLocation
{
    public partial class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private LocationsQueryManager _queryManager;

        public DeleteLocationCommandHandler(IAdventureWorksContext context, IMediator mediator, LocationsQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Locations
                .FirstOrDefaultAsync(c => c.LocationID == request.LocationID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.Location), JsonConvert.SerializeObject(new { request.LocationID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new LocationDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
