using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Purchasing;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Commands.DeleteProductVendor
{
    public partial class DeleteProductVendorCommandHandler : IRequestHandler<DeleteProductVendorCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private ProductVendorsQueryManager _queryManager;

        public DeleteProductVendorCommandHandler(IAdventureWorksContext context, IMediator mediator, ProductVendorsQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteProductVendorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductVendors
                .FirstOrDefaultAsync(c => c.ProductID == request.ProductID && c.VendorID == request.VendorID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.ProductVendor), JsonConvert.SerializeObject(new { request.ProductID, request.VendorID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new ProductVendorDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
