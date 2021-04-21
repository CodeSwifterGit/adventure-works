using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Queries.GetEmployeeAddresses;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.HumanResources;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.HumanResources;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Commands.CreateEmployeeAddress
{
    public partial class CreateEmployeeAddressCommand : BaseEmployeeAddress, IRequest<EmployeeAddressLookupModel>, IHaveCustomMapping
    {

        public CreateEmployeeAddressCommand()
        {

        }

        public CreateEmployeeAddressCommand(BaseEmployeeAddress model, IMapper mapper)
        {
            mapper.Map<BaseEmployeeAddress, CreateEmployeeAddressCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateEmployeeAddressCommand, EmployeeAddressLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly EmployeeAddressesQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                EmployeeAddressesQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<EmployeeAddressLookupModel> Handle(CreateEmployeeAddressCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateEmployeeAddressCommand, Entities.EmployeeAddress>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.EmployeeAddresses.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.EmployeeAddresses.FindAsync(new object[] { entity.EmployeeID, entity.AddressID }, cancellationToken);

                await _mediator.Publish(new EmployeeAddressCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.EmployeeAddress, EmployeeAddressLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseEmployeeAddress, CreateEmployeeAddressCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateEmployeeAddressCommand, Entities.EmployeeAddress>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
