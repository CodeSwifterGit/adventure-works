using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Commands.DeleteSpecialOfferProduct
{
    public partial class DeleteSpecialOfferProductCommandHandler : IRequestHandler<DeleteSpecialOfferProductCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private SpecialOfferProductsQueryManager _queryManager;

        public DeleteSpecialOfferProductCommandHandler(IAdventureWorksContext context, IMediator mediator, SpecialOfferProductsQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteSpecialOfferProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SpecialOfferProducts
                .FirstOrDefaultAsync(c => c.SpecialOfferID == request.SpecialOfferID && c.ProductID == request.ProductID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.SpecialOfferProduct), JsonConvert.SerializeObject(new { request.SpecialOfferID, request.ProductID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new SpecialOfferProductDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
