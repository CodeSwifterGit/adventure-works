using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Queries.GetShoppingCartItems;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Sales;


namespace AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Commands.UpdateShoppingCartItem
{
    public partial class
        UpdateShoppingCartItemSetCommandHandler : IRequestHandler<UpdateShoppingCartItemSetCommand, List<ShoppingCartItemLookupModel>>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UpdateShoppingCartItemSetCommandHandler(IAdventureWorksContext context, IMediator mediator, IMapper mapper)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<List<ShoppingCartItemLookupModel>> Handle(UpdateShoppingCartItemSetCommand request,
            CancellationToken cancellationToken)
        {
            var result = new List<ShoppingCartItemLookupModel>();
            await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
            {
                foreach (var singleRequest in request.Commands)
                {
                    var singleUpdateResult = await _mediator.Send(singleRequest, cancellationToken);
                    result.Add(singleUpdateResult);
                }

                await transaction.CommitAsync(cancellationToken);
            }
            return result;
        }
    }
}