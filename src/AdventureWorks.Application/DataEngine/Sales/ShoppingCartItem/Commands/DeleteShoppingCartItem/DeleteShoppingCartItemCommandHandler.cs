using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.ShoppingCartItem.Commands.DeleteShoppingCartItem
{
    public partial class DeleteShoppingCartItemCommandHandler : IRequestHandler<DeleteShoppingCartItemCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private ShoppingCartItemsQueryManager _queryManager;

        public DeleteShoppingCartItemCommandHandler(IAdventureWorksContext context, IMediator mediator, ShoppingCartItemsQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteShoppingCartItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ShoppingCartItems
                .FirstOrDefaultAsync(c => c.ShoppingCartItemID == request.ShoppingCartItemID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.ShoppingCartItem), JsonConvert.SerializeObject(new { request.ShoppingCartItemID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new ShoppingCartItemDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
