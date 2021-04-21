using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Purchasing;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Commands.DeleteVendorContact
{
    public partial class DeleteVendorContactCommandHandler : IRequestHandler<DeleteVendorContactCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private VendorContactsQueryManager _queryManager;

        public DeleteVendorContactCommandHandler(IAdventureWorksContext context, IMediator mediator, VendorContactsQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteVendorContactCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.VendorContacts
                .FirstOrDefaultAsync(c => c.VendorID == request.VendorID && c.ContactID == request.ContactID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.VendorContact), JsonConvert.SerializeObject(new { request.VendorID, request.ContactID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new VendorContactDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
