using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Production.ProductDescription.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductDescription.Commands.DeleteProductDescription
{
    public partial class DeleteProductDescriptionCommandHandler : IRequestHandler<DeleteProductDescriptionCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private ProductDescriptionsQueryManager _queryManager;

        public DeleteProductDescriptionCommandHandler(IAdventureWorksContext context, IMediator mediator, ProductDescriptionsQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteProductDescriptionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductDescriptions
                .FirstOrDefaultAsync(c => c.ProductDescriptionID == request.ProductDescriptionID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.ProductDescription), JsonConvert.SerializeObject(new { request.ProductDescriptionID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new ProductDescriptionDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
