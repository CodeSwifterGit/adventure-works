using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Production.WorkOrder.Queries.GetWorkOrders;
using AdventureWorks.Application.DataEngine.Production.WorkOrder.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.WorkOrder.Commands.CreateWorkOrder
{
    public partial class CreateWorkOrderCommand : BaseWorkOrder, IRequest<WorkOrderLookupModel>, IHaveCustomMapping
    {

        public CreateWorkOrderCommand()
        {

        }

        public CreateWorkOrderCommand(BaseWorkOrder model, IMapper mapper)
        {
            mapper.Map<BaseWorkOrder, CreateWorkOrderCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateWorkOrderCommand, WorkOrderLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly WorkOrdersQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                WorkOrdersQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<WorkOrderLookupModel> Handle(CreateWorkOrderCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateWorkOrderCommand, Entities.WorkOrder>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.WorkOrders.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.WorkOrders.FindAsync(new object[] { entity.WorkOrderID }, cancellationToken);

                await _mediator.Publish(new WorkOrderCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.WorkOrder, WorkOrderLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseWorkOrder, CreateWorkOrderCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateWorkOrderCommand, Entities.WorkOrder>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
