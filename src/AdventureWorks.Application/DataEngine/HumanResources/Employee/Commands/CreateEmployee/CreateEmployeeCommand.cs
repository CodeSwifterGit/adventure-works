using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.HumanResources.Employee.Queries.GetEmployees;
using AdventureWorks.Application.DataEngine.HumanResources.Employee.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.HumanResources;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.HumanResources.Employee.Commands.CreateEmployee
{
    public partial class CreateEmployeeCommand : BaseEmployee, IRequest<EmployeeLookupModel>, IHaveCustomMapping
    {

        public CreateEmployeeCommand()
        {

        }

        public CreateEmployeeCommand(BaseEmployee model, IMapper mapper)
        {
            mapper.Map<BaseEmployee, CreateEmployeeCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateEmployeeCommand, EmployeeLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly EmployeesQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                EmployeesQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<EmployeeLookupModel> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateEmployeeCommand, Entities.Employee>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.Employees.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.Employees.FindAsync(new object[] { entity.EmployeeID }, cancellationToken);

                await _mediator.Publish(new EmployeeCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.Employee, EmployeeLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseEmployee, CreateEmployeeCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateEmployeeCommand, Entities.Employee>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
