using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Commands.DeleteProductModelProductDescriptionCulture
{
    public partial class DeleteProductModelProductDescriptionCultureCommandHandler : IRequestHandler<DeleteProductModelProductDescriptionCultureCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private ProductModelProductDescriptionCulturesQueryManager _queryManager;

        public DeleteProductModelProductDescriptionCultureCommandHandler(IAdventureWorksContext context, IMediator mediator, ProductModelProductDescriptionCulturesQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteProductModelProductDescriptionCultureCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductModelProductDescriptionCultures
                .FirstOrDefaultAsync(c => c.ProductModelID == request.ProductModelID && c.ProductDescriptionID == request.ProductDescriptionID && c.CultureID == request.CultureID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.ProductModelProductDescriptionCulture), JsonConvert.SerializeObject(new { request.ProductModelID, request.ProductDescriptionID, request.CultureID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new ProductModelProductDescriptionCultureDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
