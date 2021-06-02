using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Queries.GetProductListPriceHistories;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Queries.GetProductListPriceHistoryDetail
{
    public partial class GetProductListPriceHistoryDetailQueryHandler : IRequestHandler<GetProductListPriceHistoryDetailQuery, ProductListPriceHistoryLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetProductListPriceHistoryDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductListPriceHistoryLookupModel> Handle(GetProductListPriceHistoryDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductListPriceHistories
                .FindAsync(new object[] { request.ProductID, request.StartDate }, cancellationToken);

            return _mapper.Map<Domain.Entities.Production.ProductListPriceHistory, ProductListPriceHistoryLookupModel>(entity);
        }
    }
}
