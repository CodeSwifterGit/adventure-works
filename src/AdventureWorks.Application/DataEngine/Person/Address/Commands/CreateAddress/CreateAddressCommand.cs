using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Person.Address.Queries.GetAddresses;
using AdventureWorks.Application.DataEngine.Person.Address.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Person;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Person.Address.Commands.CreateAddress
{
    public partial class CreateAddressCommand : BaseAddress, IRequest<AddressLookupModel>, IHaveCustomMapping
    {

        public CreateAddressCommand()
        {

        }

        public CreateAddressCommand(BaseAddress model, IMapper mapper)
        {
            mapper.Map<BaseAddress, CreateAddressCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateAddressCommand, AddressLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly AddressesQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                AddressesQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<AddressLookupModel> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateAddressCommand, Entities.Address>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.Addresses.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.Addresses.FindAsync(new object[] { entity.AddressID }, cancellationToken);

                await _mediator.Publish(new AddressCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.Address, AddressLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseAddress, CreateAddressCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateAddressCommand, Entities.Address>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
