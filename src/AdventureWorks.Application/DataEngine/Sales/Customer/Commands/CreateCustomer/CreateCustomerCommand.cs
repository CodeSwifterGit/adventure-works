using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Sales.Customer.Queries.GetCustomers;
using AdventureWorks.Application.DataEngine.Sales.Customer.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.Customer.Commands.CreateCustomer
{
    public partial class CreateCustomerCommand : BaseCustomer, IRequest<CustomerLookupModel>, IHaveCustomMapping
    {

        public CreateCustomerCommand()
        {

        }

        public CreateCustomerCommand(BaseCustomer model, IMapper mapper)
        {
            mapper.Map<BaseCustomer, CreateCustomerCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateCustomerCommand, CustomerLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly CustomersQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                CustomersQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<CustomerLookupModel> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateCustomerCommand, Entities.Customer>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.Customers.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.Customers.FindAsync(new object[] { entity.CustomerID }, cancellationToken);

                await _mediator.Publish(new CustomerCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.Customer, CustomerLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseCustomer, CreateCustomerCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateCustomerCommand, Entities.Customer>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
