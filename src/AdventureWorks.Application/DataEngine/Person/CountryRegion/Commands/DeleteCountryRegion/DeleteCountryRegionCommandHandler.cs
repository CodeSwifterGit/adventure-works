using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Person.CountryRegion.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Person;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Person.CountryRegion.Commands.DeleteCountryRegion
{
    public partial class DeleteCountryRegionCommandHandler : IRequestHandler<DeleteCountryRegionCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private CountryRegionsQueryManager _queryManager;

        public DeleteCountryRegionCommandHandler(IAdventureWorksContext context, IMediator mediator, CountryRegionsQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteCountryRegionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.CountryRegions
                .FirstOrDefaultAsync(c => c.CountryRegionCode == request.CountryRegionCode, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.CountryRegion), JsonConvert.SerializeObject(new { request.CountryRegionCode }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new CountryRegionDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
