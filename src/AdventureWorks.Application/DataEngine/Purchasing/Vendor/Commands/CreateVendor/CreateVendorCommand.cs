using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Purchasing.Vendor.Queries.GetVendors;
using AdventureWorks.Application.DataEngine.Purchasing.Vendor.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Purchasing;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Purchasing.Vendor.Commands.CreateVendor
{
    public partial class CreateVendorCommand : BaseVendor, IRequest<VendorLookupModel>, IHaveCustomMapping
    {

        public CreateVendorCommand()
        {

        }

        public CreateVendorCommand(BaseVendor model, IMapper mapper)
        {
            mapper.Map<BaseVendor, CreateVendorCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateVendorCommand, VendorLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly VendorsQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                VendorsQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<VendorLookupModel> Handle(CreateVendorCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateVendorCommand, Entities.Vendor>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.Vendors.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.Vendors.FindAsync(new object[] { entity.VendorID }, cancellationToken);

                await _mediator.Publish(new VendorCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.Vendor, VendorLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseVendor, CreateVendorCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateVendorCommand, Entities.Vendor>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
