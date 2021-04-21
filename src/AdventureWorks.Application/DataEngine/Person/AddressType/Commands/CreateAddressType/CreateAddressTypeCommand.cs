using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Person.AddressType.Queries.GetAddressTypes;
using AdventureWorks.Application.DataEngine.Person.AddressType.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Person;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Person;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Person.AddressType.Commands.CreateAddressType
{
    public partial class CreateAddressTypeCommand : BaseAddressType, IRequest<AddressTypeLookupModel>, IHaveCustomMapping
    {

        public CreateAddressTypeCommand()
        {

        }

        public CreateAddressTypeCommand(BaseAddressType model, IMapper mapper)
        {
            mapper.Map<BaseAddressType, CreateAddressTypeCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateAddressTypeCommand, AddressTypeLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly AddressTypesQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                AddressTypesQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<AddressTypeLookupModel> Handle(CreateAddressTypeCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateAddressTypeCommand, Entities.AddressType>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.AddressTypes.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.AddressTypes.FindAsync(new object[] { entity.AddressTypeID }, cancellationToken);

                await _mediator.Publish(new AddressTypeCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.AddressType, AddressTypeLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseAddressType, CreateAddressTypeCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateAddressTypeCommand, Entities.AddressType>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
