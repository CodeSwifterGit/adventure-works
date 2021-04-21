using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Purchasing;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Commands.DeleteVendorAddress
{
    public partial class DeleteVendorAddressCommandHandler : IRequestHandler<DeleteVendorAddressCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private VendorAddressesQueryManager _queryManager;

        public DeleteVendorAddressCommandHandler(IAdventureWorksContext context, IMediator mediator, VendorAddressesQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteVendorAddressCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.VendorAddresses
                .FirstOrDefaultAsync(c => c.VendorID == request.VendorID && c.AddressID == request.AddressID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.VendorAddress), JsonConvert.SerializeObject(new { request.VendorID, request.AddressID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new VendorAddressDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
