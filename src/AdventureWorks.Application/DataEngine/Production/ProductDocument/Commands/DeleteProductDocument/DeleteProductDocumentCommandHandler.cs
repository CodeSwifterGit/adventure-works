using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Production.ProductDocument.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductDocument.Commands.DeleteProductDocument
{
    public partial class DeleteProductDocumentCommandHandler : IRequestHandler<DeleteProductDocumentCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private ProductDocumentsQueryManager _queryManager;

        public DeleteProductDocumentCommandHandler(IAdventureWorksContext context, IMediator mediator, ProductDocumentsQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteProductDocumentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductDocuments
                .FirstOrDefaultAsync(c => c.ProductID == request.ProductID && c.DocumentID == request.DocumentID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.ProductDocument), JsonConvert.SerializeObject(new { request.ProductID, request.DocumentID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new ProductDocumentDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
