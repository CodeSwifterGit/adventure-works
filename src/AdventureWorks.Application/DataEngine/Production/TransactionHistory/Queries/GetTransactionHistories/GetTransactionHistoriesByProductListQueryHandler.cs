using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.TransactionHistory.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.TransactionHistory.Queries.GetTransactionHistories
{
    public partial class GetTransactionHistoriesByProductListQueryHandler : IRequestHandler<GetTransactionHistoriesByProductListQuery, TransactionHistoriesListViewModel>
    {
        private readonly TransactionHistoriesQueryManager _queryManager;

        public GetTransactionHistoriesByProductListQueryHandler(TransactionHistoriesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<TransactionHistoriesListViewModel> Handle(GetTransactionHistoriesByProductListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.ProductID == request.ProductID);

            var listResult =
                      await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new TransactionHistoriesListViewModel
            {
                TransactionHistories = listResult,
                DataTable = DataTableResponseInfo<TransactionHistorySummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
