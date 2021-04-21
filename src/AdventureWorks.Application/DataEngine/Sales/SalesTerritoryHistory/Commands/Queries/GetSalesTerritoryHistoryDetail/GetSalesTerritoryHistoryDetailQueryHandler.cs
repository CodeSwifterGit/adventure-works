using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Queries.GetSalesTerritoryHistories;
using AdventureWorks.Application.Exceptions;
using AdventureWorks.Domain;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Queries.GetSalesTerritoryHistoryDetail
{
    public partial class GetSalesTerritoryHistoryDetailQueryHandler : IRequestHandler<GetSalesTerritoryHistoryDetailQuery, SalesTerritoryHistoryLookupModel>
    {
        private readonly IAdventureWorksContext _context;
        private readonly IMapper _mapper;

        public GetSalesTerritoryHistoryDetailQueryHandler(IAdventureWorksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SalesTerritoryHistoryLookupModel> Handle(GetSalesTerritoryHistoryDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.SalesTerritoryHistories
                .FindAsync(new object[] { request.SalesPersonID, request.TerritoryID, request.StartDate }, cancellationToken);

            return _mapper.Map<Domain.Entities.Sales.SalesTerritoryHistory, SalesTerritoryHistoryLookupModel>(entity);
        }
    }
}
