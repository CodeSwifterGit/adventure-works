using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Queries.GetShoppingCartItems;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Queries.GetShoppingCartItemDetail
{
    public partial class GetShoppingCartItemDetailQueryHandler : IRequestHandler<GetShoppingCartItemDetailQuery, ShoppingCartItemLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetShoppingCartItemDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ShoppingCartItemLookupModel> Handle(GetShoppingCartItemDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.ShoppingCartItems
                .FindAsync(new object[] { request.ShoppingCartItemID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Sales.ShoppingCartItem, ShoppingCartItemLookupModel>(entity);
        }
    }
}
