using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Queries.GetWorkOrderRoutings;
using AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.WorkOrderRouting.Commands.CreateWorkOrderRouting
{
    public partial class CreateWorkOrderRoutingCommand : BaseWorkOrderRouting, IRequest<WorkOrderRoutingLookupModel>, IHaveCustomMapping
    {

        public CreateWorkOrderRoutingCommand()
        {

        }

        public CreateWorkOrderRoutingCommand(BaseWorkOrderRouting model, IMapper mapper)
        {
            mapper.Map<BaseWorkOrderRouting, CreateWorkOrderRoutingCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateWorkOrderRoutingCommand, WorkOrderRoutingLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly WorkOrderRoutingsQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                WorkOrderRoutingsQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<WorkOrderRoutingLookupModel> Handle(CreateWorkOrderRoutingCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateWorkOrderRoutingCommand, Entities.WorkOrderRouting>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.WorkOrderRoutings.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.WorkOrderRoutings.FindAsync(new object[] { entity.WorkOrderID, entity.ProductID, entity.OperationSequence }, cancellationToken);

                await _mediator.Publish(new WorkOrderRoutingCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.WorkOrderRouting, WorkOrderRoutingLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseWorkOrderRouting, CreateWorkOrderRoutingCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateWorkOrderRoutingCommand, Entities.WorkOrderRouting>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
