using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Production.UnitMeasure.Queries.GetUnitMeasures;
using AdventureWorks.Application.DataEngine.Production.UnitMeasure.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.UnitMeasure.Commands.CreateUnitMeasure
{
    public partial class CreateUnitMeasureCommand : BaseUnitMeasure, IRequest<UnitMeasureLookupModel>, IHaveCustomMapping
    {

        public CreateUnitMeasureCommand()
        {

        }

        public CreateUnitMeasureCommand(BaseUnitMeasure model, IMapper mapper)
        {
            mapper.Map<BaseUnitMeasure, CreateUnitMeasureCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateUnitMeasureCommand, UnitMeasureLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly UnitMeasuresQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                UnitMeasuresQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<UnitMeasureLookupModel> Handle(CreateUnitMeasureCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateUnitMeasureCommand, Entities.UnitMeasure>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.UnitMeasures.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.UnitMeasures.FindAsync(new object[] { entity.UnitMeasureCode }, cancellationToken);

                await _mediator.Publish(new UnitMeasureCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.UnitMeasure, UnitMeasureLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseUnitMeasure, CreateUnitMeasureCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateUnitMeasureCommand, Entities.UnitMeasure>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
