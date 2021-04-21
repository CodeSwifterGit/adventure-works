using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Sales.StoreContact.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.StoreContact.Commands.DeleteStoreContact
{
    public partial class DeleteStoreContactCommandHandler : IRequestHandler<DeleteStoreContactCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private StoreContactsQueryManager _queryManager;

        public DeleteStoreContactCommandHandler(IAdventureWorksContext context, IMediator mediator, StoreContactsQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteStoreContactCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.StoreContacts
                .FirstOrDefaultAsync(c => c.CustomerID == request.CustomerID && c.ContactID == request.ContactID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.StoreContact), JsonConvert.SerializeObject(new { request.CustomerID, request.ContactID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new StoreContactDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
