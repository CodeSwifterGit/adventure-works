using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Production.ProductModel.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductModel.Commands.DeleteProductModel
{
    public partial class DeleteProductModelCommandHandler : IRequestHandler<DeleteProductModelCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private ProductModelsQueryManager _queryManager;

        public DeleteProductModelCommandHandler(IAdventureWorksContext context, IMediator mediator, ProductModelsQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteProductModelCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductModels
                .FirstOrDefaultAsync(c => c.ProductModelID == request.ProductModelID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.ProductModel), JsonConvert.SerializeObject(new { request.ProductModelID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new ProductModelDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
