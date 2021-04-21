using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.DataEngine.Production.ProductReview.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;
using Newtonsoft.Json;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductReview.Commands.DeleteProductReview
{
    public partial class DeleteProductReviewCommandHandler : IRequestHandler<DeleteProductReviewCommand>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMediator _mediator;
        private ProductReviewsQueryManager _queryManager;

        public DeleteProductReviewCommandHandler(IAdventureWorksContext context, IMediator mediator, ProductReviewsQueryManager queryManager)
        {
            _context = context;
            _mediator = mediator;
            _queryManager = queryManager;
        }

        public async Task<Unit> Handle(DeleteProductReviewCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductReviews
                .FirstOrDefaultAsync(c => c.ProductReviewID == request.ProductReviewID, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Entities.ProductReview), JsonConvert.SerializeObject(new { request.ProductReviewID }).Replace("{", "[").Replace("}", "]"));
            }

            await _queryManager.PreDeleteActionAsync(entity, cancellationToken);

            var isDeletedWithChildren = await _queryManager.RemoveDependentRows(entity, cancellationToken);
            if (!isDeletedWithChildren)
            {
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync(cancellationToken);
            }

            await _mediator.Publish(new ProductReviewDeleted()
            {
                Entity = entity
            }, cancellationToken);

            return Unit.Value;
        }
    }
}
