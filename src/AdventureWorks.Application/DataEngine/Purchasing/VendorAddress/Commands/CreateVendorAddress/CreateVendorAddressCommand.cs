using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Queries.GetVendorAddresses;
using AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Purchasing;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Commands.CreateVendorAddress
{
    public partial class CreateVendorAddressCommand : BaseVendorAddress, IRequest<VendorAddressLookupModel>, IHaveCustomMapping
    {

        public CreateVendorAddressCommand()
        {

        }

        public CreateVendorAddressCommand(BaseVendorAddress model, IMapper mapper)
        {
            mapper.Map<BaseVendorAddress, CreateVendorAddressCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateVendorAddressCommand, VendorAddressLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly VendorAddressesQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                VendorAddressesQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<VendorAddressLookupModel> Handle(CreateVendorAddressCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateVendorAddressCommand, Entities.VendorAddress>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.VendorAddresses.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.VendorAddresses.FindAsync(new object[] { entity.VendorID, entity.AddressID }, cancellationToken);

                await _mediator.Publish(new VendorAddressCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.VendorAddress, VendorAddressLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseVendorAddress, CreateVendorAddressCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateVendorAddressCommand, Entities.VendorAddress>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
