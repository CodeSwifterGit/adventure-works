using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Person.CountryRegion.Queries.GetCountryRegions;
using AdventureWorks.Application.DataEngine.Person.CountryRegion.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Person;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Person.CountryRegion.Commands.CreateCountryRegion
{
    public partial class CreateCountryRegionCommand : BaseCountryRegion, IRequest<CountryRegionLookupModel>, IHaveCustomMapping
    {

        public CreateCountryRegionCommand()
        {

        }

        public CreateCountryRegionCommand(BaseCountryRegion model, IMapper mapper)
        {
            mapper.Map<BaseCountryRegion, CreateCountryRegionCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateCountryRegionCommand, CountryRegionLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly CountryRegionsQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                CountryRegionsQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<CountryRegionLookupModel> Handle(CreateCountryRegionCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateCountryRegionCommand, Entities.CountryRegion>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.CountryRegions.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.CountryRegions.FindAsync(new object[] { entity.CountryRegionCode }, cancellationToken);

                await _mediator.Publish(new CountryRegionCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.CountryRegion, CountryRegionLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseCountryRegion, CreateCountryRegionCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateCountryRegionCommand, Entities.CountryRegion>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
