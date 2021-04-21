using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesReason.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.SalesReason.Queries.GetSalesReasons
{
    public partial class GetSalesReasonsListQueryHandler : IRequestHandler<GetSalesReasonsListQuery, SalesReasonsListViewModel>
    {
        private readonly SalesReasonsQueryManager _queryManager;

        public GetSalesReasonsListQueryHandler(SalesReasonsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<SalesReasonsListViewModel> Handle(GetSalesReasonsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new SalesReasonsListViewModel
            {
                SalesReasons = listResult,
                DataTable = DataTableResponseInfo<SalesReasonSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
