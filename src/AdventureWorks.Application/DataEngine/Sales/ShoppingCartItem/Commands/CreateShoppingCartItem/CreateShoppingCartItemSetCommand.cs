using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Queries.GetShoppingCartItems;
using AdventureWorks.BaseDomain.Entities.Sales;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Commands.CreateShoppingCartItem
{
    public partial class CreateShoppingCartItemSetCommand : IRequest<List<ShoppingCartItemLookupModel>>
    {
        public List<BaseShoppingCartItem> ShoppingCartItems { get; set; }

        public CreateShoppingCartItemSetCommand()
        {
        }

        public CreateShoppingCartItemSetCommand(List<BaseShoppingCartItem> model)
        {
            ShoppingCartItems = model;
        }

        public partial class Handler : IRequestHandler<CreateShoppingCartItemSetCommand, List<ShoppingCartItemLookupModel>>
        {
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;

            public Handler(IAdventureWorksContext context, IMediator mediator, IMapper mapper)
            {
                _context = context;
                _mediator = mediator;
                _mapper = mapper;
            }

            public async Task<List<ShoppingCartItemLookupModel>> Handle(CreateShoppingCartItemSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<ShoppingCartItemLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.ShoppingCartItems)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateShoppingCartItemCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}