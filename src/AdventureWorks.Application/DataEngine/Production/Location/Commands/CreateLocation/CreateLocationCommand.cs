using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Production.Location.Queries.GetLocations;
using AdventureWorks.Application.DataEngine.Production.Location.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.Location.Commands.CreateLocation
{
    public partial class CreateLocationCommand : BaseLocation, IRequest<LocationLookupModel>, IHaveCustomMapping
    {

        public CreateLocationCommand()
        {

        }

        public CreateLocationCommand(BaseLocation model, IMapper mapper)
        {
            mapper.Map<BaseLocation, CreateLocationCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateLocationCommand, LocationLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly LocationsQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                LocationsQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<LocationLookupModel> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateLocationCommand, Entities.Location>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.Locations.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.Locations.FindAsync(new object[] { entity.LocationID }, cancellationToken);

                await _mediator.Publish(new LocationCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.Location, LocationLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseLocation, CreateLocationCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateLocationCommand, Entities.Location>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
