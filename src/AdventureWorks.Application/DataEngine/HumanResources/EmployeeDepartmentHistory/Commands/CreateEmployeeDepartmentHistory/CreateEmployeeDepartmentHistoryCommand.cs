using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Queries.GetEmployeeDepartmentHistories;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.HumanResources;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeDepartmentHistory.Commands.CreateEmployeeDepartmentHistory
{
    public partial class CreateEmployeeDepartmentHistoryCommand : BaseEmployeeDepartmentHistory, IRequest<EmployeeDepartmentHistoryLookupModel>, IHaveCustomMapping
    {

        public CreateEmployeeDepartmentHistoryCommand()
        {

        }

        public CreateEmployeeDepartmentHistoryCommand(BaseEmployeeDepartmentHistory model, IMapper mapper)
        {
            mapper.Map<BaseEmployeeDepartmentHistory, CreateEmployeeDepartmentHistoryCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateEmployeeDepartmentHistoryCommand, EmployeeDepartmentHistoryLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly EmployeeDepartmentHistoriesQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                EmployeeDepartmentHistoriesQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<EmployeeDepartmentHistoryLookupModel> Handle(CreateEmployeeDepartmentHistoryCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateEmployeeDepartmentHistoryCommand, Entities.EmployeeDepartmentHistory>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.EmployeeDepartmentHistories.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.EmployeeDepartmentHistories.FindAsync(new object[] { entity.EmployeeID, entity.DepartmentID, entity.ShiftID, entity.StartDate }, cancellationToken);

                await _mediator.Publish(new EmployeeDepartmentHistoryCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.EmployeeDepartmentHistory, EmployeeDepartmentHistoryLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseEmployeeDepartmentHistory, CreateEmployeeDepartmentHistoryCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateEmployeeDepartmentHistoryCommand, Entities.EmployeeDepartmentHistory>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
