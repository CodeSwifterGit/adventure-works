using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application.Interfaces.Mapping;
using AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Queries.GetShoppingCartItems;
using AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Queries.QueryManager;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Common.Interfaces;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;
using AdventureWorks.Common.Extensions;

namespace AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Commands.CreateShoppingCartItem
{
    public partial class CreateShoppingCartItemCommand : BaseShoppingCartItem, IRequest<ShoppingCartItemLookupModel>, IHaveCustomMapping
    {

        public CreateShoppingCartItemCommand()
        {

        }

        public CreateShoppingCartItemCommand(BaseShoppingCartItem model, IMapper mapper)
        {
            mapper.Map<BaseShoppingCartItem, CreateShoppingCartItemCommand>(model, this);
        }

        public partial class Handler : IRequestHandler<CreateShoppingCartItemCommand, ShoppingCartItemLookupModel>
        {
            private readonly IAuthenticatedUserService _authenticatedUserService;
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDateTime _machineDateTime;
            private readonly ShoppingCartItemsQueryManager _queryManager;

            public Handler(IAdventureWorksContext context,
                IAuthenticatedUserService authenticatedUserService, IMediator mediator, IMapper mapper, IDateTime machineDateTime,
                ShoppingCartItemsQueryManager queryManager)
            {
                _context = context;
                _authenticatedUserService = authenticatedUserService;
                _mediator = mediator;
                _mapper = mapper;
                _machineDateTime = machineDateTime;
                _queryManager = queryManager;
            }

            public async Task<ShoppingCartItemLookupModel> Handle(CreateShoppingCartItemCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<CreateShoppingCartItemCommand, Entities.ShoppingCartItem>(request);

                entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
                entity.ModifiedAt = _machineDateTime.UtcNow;

                _context.ShoppingCartItems.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                _context.ChangeTracker.Clear();
                entity = await _context.ShoppingCartItems.FindAsync(new object[] { entity.ShoppingCartItemID }, cancellationToken);

                await _mediator.Publish(new ShoppingCartItemCreated
                {
                    Entity = entity
                }, cancellationToken);


                await _queryManager.PostCreateActionAsync(entity, cancellationToken);

                return _mapper.Map<Entities.ShoppingCartItem, ShoppingCartItemLookupModel>(entity);
            }
        }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<BaseShoppingCartItem, CreateShoppingCartItemCommand>(MemberList.Source).IgnoreMissingDestinationMembers();
            configuration.CreateMap<CreateShoppingCartItemCommand, Entities.ShoppingCartItem>(MemberList.None).IgnoreMissingDestinationMembers();
        }
    }
}
