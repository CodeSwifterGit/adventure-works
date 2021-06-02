using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductReview.Queries.GetProductReviews;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Production.ProductReview.Queries.GetProductReviewDetail
{
    public partial class GetProductReviewDetailQueryHandler : IRequestHandler<GetProductReviewDetailQuery, ProductReviewLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetProductReviewDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductReviewLookupModel> Handle(GetProductReviewDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductReviews
                .FindAsync(new object[] { request.ProductReviewID }, cancellationToken);

            return _mapper.Map<Domain.Entities.Production.ProductReview, ProductReviewLookupModel>(entity);
        }
    }
}
