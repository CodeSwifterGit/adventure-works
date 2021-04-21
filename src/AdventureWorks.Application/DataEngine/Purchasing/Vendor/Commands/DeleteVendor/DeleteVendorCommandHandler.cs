using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Purchasing.Vendor.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Purchasing;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.Vendor.Commands.DeleteVendor
{
    public partial class DeleteVendorCommandHandler : IRequestHandler<DeleteVendorCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private VendorsQueryManager _queryManager;

        public DeleteVendorCommandHandler(IAdventureWorksContext context, IMediator mediator, VendorsQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteVendorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Vendors
                .FirstOrDefaultAsync(c => c.VendorID == request.VendorID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.Vendor), JsonConvert.SerializeObject(new { request.VendorID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new VendorDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
