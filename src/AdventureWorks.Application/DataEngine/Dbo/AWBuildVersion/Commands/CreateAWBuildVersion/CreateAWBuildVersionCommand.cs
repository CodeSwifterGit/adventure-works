using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Queries.GetAWBuildVersions;
using AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Dbo;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Dbo;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Dbo.AWBuildVersion.Commands.CreateAWBuildVersion
{
    public partial class CreateAWBuildVersionCommand : BaseAWBuildVersion, IRequest<AWBuildVersionLookupModel>, IHaveCustomMapping
    {

        public CreateAWBuildVersionCommand()
        {

        }

        public CreateAWBuildVersionCommand(BaseAWBuildVersion model, IMapper mapper)
        {
            mapper.Map<BaseAWBuildVersion, CreateAWBuildVersionCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateAWBuildVersionCommand, AWBuildVersionLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly AWBuildVersionsQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                AWBuildVersionsQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<AWBuildVersionLookupModel> Handle(CreateAWBuildVersionCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateAWBuildVersionCommand, Entities.AWBuildVersion>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.AWBuildVersions.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.AWBuildVersions.FindAsync(new object[] { entity.SystemInformationID }, cancellationToken);

                await _mediator.Publish(new AWBuildVersionCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.AWBuildVersion, AWBuildVersionLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseAWBuildVersion, CreateAWBuildVersionCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateAWBuildVersionCommand, Entities.AWBuildVersion>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
