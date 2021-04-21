using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesPersonQuotaHistory.Queries.GetSalesPersonQuotaHistories
{
    public partial class GetSalesPersonQuotaHistoriesBySalesPersonListQueryHandler : IRequestHandler<GetSalesPersonQuotaHistoriesBySalesPersonListQuery, SalesPersonQuotaHistoriesListViewModel>
    {
        private readonly SalesPersonQuotaHistoriesQueryManager _queryManager;

        public GetSalesPersonQuotaHistoriesBySalesPersonListQueryHandler(SalesPersonQuotaHistoriesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<SalesPersonQuotaHistoriesListViewModel> Handle(GetSalesPersonQuotaHistoriesBySalesPersonListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.SalesPersonID == request.SalesPersonID);

            var listResult =
                      await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new SalesPersonQuotaHistoriesListViewModel
            {
                SalesPersonQuotaHistories = listResult,
                DataTable = DataTableResponseInfo<SalesPersonQuotaHistorySummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
