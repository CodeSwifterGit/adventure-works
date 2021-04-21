using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Queries.GetProductVendors;
using AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Purchasing;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Purchasing;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Commands.CreateProductVendor
{
    public partial class CreateProductVendorCommand : BaseProductVendor, IRequest<ProductVendorLookupModel>, IHaveCustomMapping
    {

        public CreateProductVendorCommand()
        {

        }

        public CreateProductVendorCommand(BaseProductVendor model, IMapper mapper)
        {
            mapper.Map<BaseProductVendor, CreateProductVendorCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateProductVendorCommand, ProductVendorLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly ProductVendorsQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                ProductVendorsQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<ProductVendorLookupModel> Handle(CreateProductVendorCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateProductVendorCommand, Entities.ProductVendor>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.ProductVendors.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.ProductVendors.FindAsync(new object[] { entity.ProductID, entity.VendorID }, cancellationToken);

                await _mediator.Publish(new ProductVendorCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.ProductVendor, ProductVendorLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseProductVendor, CreateProductVendorCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateProductVendorCommand, Entities.ProductVendor>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
