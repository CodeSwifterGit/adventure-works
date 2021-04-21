using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.HumanResources.Department.Queries.GetDepartments;
using AdventureWorks.Application.DataEngine.HumanResources.Department.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.HumanResources;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.HumanResources.Department.Commands.CreateDepartment
{
    public partial class CreateDepartmentCommand : BaseDepartment, IRequest<DepartmentLookupModel>, IHaveCustomMapping
    {

        public CreateDepartmentCommand()
        {

        }

        public CreateDepartmentCommand(BaseDepartment model, IMapper mapper)
        {
            mapper.Map<BaseDepartment, CreateDepartmentCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateDepartmentCommand, DepartmentLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly DepartmentsQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                DepartmentsQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<DepartmentLookupModel> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateDepartmentCommand, Entities.Department>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.Departments.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.Departments.FindAsync(new object[] { entity.DepartmentID }, cancellationToken);

                await _mediator.Publish(new DepartmentCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.Department, DepartmentLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseDepartment, CreateDepartmentCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateDepartmentCommand, Entities.Department>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
