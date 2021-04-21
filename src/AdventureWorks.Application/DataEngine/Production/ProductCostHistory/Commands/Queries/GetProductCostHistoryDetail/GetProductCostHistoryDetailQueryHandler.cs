using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Queries.GetProductCostHistories;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Queries.GetProductCostHistoryDetail
{
    public partial class GetProductCostHistoryDetailQueryHandler : IRequestHandler<GetProductCostHistoryDetailQuery, ProductCostHistoryLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetProductCostHistoryDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductCostHistoryLookupModel> Handle(GetProductCostHistoryDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductCostHistories
                .FindAsync(new object[] { request.ProductID, request.StartDate }, cancellationToken);

            return _mapper.Map<Domain.Entities.Production.ProductCostHistory, ProductCostHistoryLookupModel>(entity);
        }
    }
}
