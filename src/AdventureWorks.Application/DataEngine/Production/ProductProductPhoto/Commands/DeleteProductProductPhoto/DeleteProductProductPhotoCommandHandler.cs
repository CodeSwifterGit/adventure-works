using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductProductPhoto.Commands.DeleteProductProductPhoto
{
    public partial class DeleteProductProductPhotoCommandHandler : IRequestHandler<DeleteProductProductPhotoCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private ProductProductPhotosQueryManager _queryManager;

        public DeleteProductProductPhotoCommandHandler(IAdventureWorksContext context, IMediator mediator, ProductProductPhotosQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteProductProductPhotoCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductProductPhotos
                .FirstOrDefaultAsync(c => c.ProductID == request.ProductID && c.ProductPhotoID == request.ProductPhotoID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.ProductProductPhoto), JsonConvert.SerializeObject(new { request.ProductID, request.ProductPhotoID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new ProductProductPhotoDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
