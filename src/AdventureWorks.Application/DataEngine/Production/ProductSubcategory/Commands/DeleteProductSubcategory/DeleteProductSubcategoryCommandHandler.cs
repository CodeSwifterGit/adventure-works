using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductSubcategory.Commands.DeleteProductSubcategory
{
    public partial class DeleteProductSubcategoryCommandHandler : IRequestHandler<DeleteProductSubcategoryCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private ProductSubcategoriesQueryManager _queryManager;

        public DeleteProductSubcategoryCommandHandler(IAdventureWorksContext context, IMediator mediator, ProductSubcategoriesQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteProductSubcategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductSubcategories
                .FirstOrDefaultAsync(c => c.ProductSubcategoryID == request.ProductSubcategoryID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.ProductSubcategory), JsonConvert.SerializeObject(new { request.ProductSubcategoryID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new ProductSubcategoryDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
