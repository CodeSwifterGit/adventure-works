using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Sales.Store.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.Store.Commands.DeleteStore
{
    public partial class DeleteStoreCommandHandler : IRequestHandler<DeleteStoreCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private StoresQueryManager _queryManager;

        public DeleteStoreCommandHandler(IAdventureWorksContext context, IMediator mediator, StoresQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Stores
                .FirstOrDefaultAsync(c => c.CustomerID == request.CustomerID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.Store), JsonConvert.SerializeObject(new { request.CustomerID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new StoreDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
