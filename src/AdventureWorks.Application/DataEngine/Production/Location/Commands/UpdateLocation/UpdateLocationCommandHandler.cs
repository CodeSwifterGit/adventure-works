using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.Location.Queries.GetLocations;
using AdventureWorks.Application.DataEngine.Production.Location.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.Location.Commands.UpdateLocation
{
    public partial class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, LocationLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly LocationsQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateLocationCommandHandler(IAdventureWorksContext context,
            LocationsQueryManager queryManager,
            IAuthenticatedUserService authenticatedUserService,
            IMediator mediator,
            IMapper mapper,
            IDateTime machineDateTime)
        {
            _context = context;
            _queryManager = queryManager;
            _authenticatedUserService = authenticatedUserService;
            _mediator = mediator;
            _mapper = mapper;
            _machineDateTime = machineDateTime;
        }

        public async Task<LocationLookupModel> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Locations
                .SingleAsync(c => c.LocationID == request.RequestTarget.LocationID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.Location, UpdateLocationCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Location), JsonConvert.SerializeObject(new { request.RequestTarget.LocationID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.Locations.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.Locations.SingleAsync(c => c.LocationID == request.RequestTarget.LocationID, cancellationToken);

            await _mediator.Publish(new LocationUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.Location, LocationLookupModel>(entity);
        }
    }
}
