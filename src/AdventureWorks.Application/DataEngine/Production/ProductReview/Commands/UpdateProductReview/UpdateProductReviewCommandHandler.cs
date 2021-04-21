using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductReview.Queries.GetProductReviews;
using AdventureWorks.Application.DataEngine.Production.ProductReview.Queries.QueryManager;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Common.Interfaces;
using AdventureWorks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.ProductReview.Commands.UpdateProductReview
{
    public partial class UpdateProductReviewCommandHandler : IRequestHandler<UpdateProductReviewCommand, ProductReviewLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly ProductReviewsQueryManager _queryManager;
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IMapper _mapper;
        private readonly IDateTime _machineDateTime;

        public UpdateProductReviewCommandHandler(IAdventureWorksContext context,
            ProductReviewsQueryManager queryManager,
            IAuthenticatedUserService authenticatedUserService,
            IMediator mediator,
            IMapper mapper,
            IDateTime machineDateTime)
        {
            _context = context;
            _queryManager = queryManager;
            _authenticatedUserService = authenticatedUserService;
            _mediator = mediator;
            _mapper = mapper;
            _machineDateTime = machineDateTime;
        }

        public async Task<ProductReviewLookupModel> Handle(UpdateProductReviewCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductReviews
                .SingleAsync(c => c.ProductReviewID == request.RequestTarget.ProductReviewID, cancellationToken);
            var oldEntity = _mapper.Map<Entities.ProductReview, UpdateProductReviewCommand>(entity);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductReview), JsonConvert.SerializeObject(new { request.RequestTarget.ProductReviewID }).Replace("{", "[").Replace("}", "]"));
            }

            var dependentUpdateResult = await _queryManager.UpdateEntityAndDependentRows(entity, request, cancellationToken);
            if (dependentUpdateResult.IsEntityReplaced)
                entity = dependentUpdateResult.Entity;

            _mapper.Map(request, entity);
            entity.ModifiedBy = _authenticatedUserService.BundledUserInfo();
            entity.ModifiedAt = _machineDateTime.UtcNow;

            _context.ProductReviews.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            entity = await _context.ProductReviews.SingleAsync(c => c.ProductReviewID == request.RequestTarget.ProductReviewID, cancellationToken);

            await _mediator.Publish(new ProductReviewUpdated()
            {
                Entity = entity
            }, cancellationToken);

            await _queryManager.PostUpdateActionAsync(oldEntity, entity, cancellationToken);

            return _mapper.Map<Entities.ProductReview, ProductReviewLookupModel>(entity);
        }
    }
}
