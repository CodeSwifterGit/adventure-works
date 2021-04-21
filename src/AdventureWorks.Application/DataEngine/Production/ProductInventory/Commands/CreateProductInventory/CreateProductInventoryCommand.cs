using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Production.ProductInventory.Queries.GetProductInventories;
using AdventureWorks.Application.DataEngine.Production.ProductInventory.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Production.ProductInventory.Commands.CreateProductInventory
{
    public partial class CreateProductInventoryCommand : BaseProductInventory, IRequest<ProductInventoryLookupModel>, IHaveCustomMapping
    {

        public CreateProductInventoryCommand()
        {

        }

        public CreateProductInventoryCommand(BaseProductInventory model, IMapper mapper)
        {
            mapper.Map<BaseProductInventory, CreateProductInventoryCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateProductInventoryCommand, ProductInventoryLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly ProductInventoriesQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                ProductInventoriesQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<ProductInventoryLookupModel> Handle(CreateProductInventoryCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateProductInventoryCommand, Entities.ProductInventory>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.ProductInventories.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.ProductInventories.FindAsync(new object[] { entity.ProductID, entity.LocationID }, cancellationToken);

                await _mediator.Publish(new ProductInventoryCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.ProductInventory, ProductInventoryLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseProductInventory, CreateProductInventoryCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateProductInventoryCommand, Entities.ProductInventory>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
