using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Commands.DeleteProductModelIllustration
{
    public partial class DeleteProductModelIllustrationCommandHandler : IRequestHandler<DeleteProductModelIllustrationCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private ProductModelIllustrationsQueryManager _queryManager;

        public DeleteProductModelIllustrationCommandHandler(IAdventureWorksContext context, IMediator mediator, ProductModelIllustrationsQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteProductModelIllustrationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductModelIllustrations
                .FirstOrDefaultAsync(c => c.ProductModelID == request.ProductModelID && c.IllustrationID == request.IllustrationID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.ProductModelIllustration), JsonConvert.SerializeObject(new { request.ProductModelID, request.IllustrationID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new ProductModelIllustrationDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
