using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductReview.Queries.GetProductReviews;
using AdventureWorks.BaseDomain.Entities.Production;
using AdventureWorks.Domain;
using MediatR;
using Entities = AdventureWorks.Domain.Entities.Production;


namespace AdventureWorks.Application.DataEngine.Production.ProductReview.Commands.CreateProductReview
{
    public partial class CreateProductReviewSetCommand : IRequest<List<ProductReviewLookupModel>>
    {
        public List<BaseProductReview> ProductReviews { get; set; }

        public CreateProductReviewSetCommand()
        {
        }

        public CreateProductReviewSetCommand(List<BaseProductReview> model)
        {
            ProductReviews = model;
        }

        public partial class Handler : IRequestHandler<CreateProductReviewSetCommand, List<ProductReviewLookupModel>>
        {
            private readonly IAdventureWorksContext _context;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;

            public Handler(IAdventureWorksContext context, IMediator mediator, IMapper mapper)
            {
                _context = context;
                _mediator = mediator;
                _mapper = mapper;
            }

            public async Task<List<ProductReviewLookupModel>> Handle(CreateProductReviewSetCommand request,
                CancellationToken cancellationToken)
            {
                var result = new List<ProductReviewLookupModel>();
                await using (var transaction = await _context.Database.BeginTransactionAsync(cancellationToken))
                {
                    foreach (var model in request.ProductReviews)
                    {
                        var singleCreateResult = await _mediator.Send(
                            new CreateProductReviewCommand(model, _mapper), cancellationToken);

                        result.Add(singleCreateResult);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }

                return result;
            }
        }
    }
}