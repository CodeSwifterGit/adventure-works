using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.TransactionHistory.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.TransactionHistory.Queries.GetTransactionHistories
{
    public partial class GetTransactionHistoriesListQueryHandler : IRequestHandler<GetTransactionHistoriesListQuery, TransactionHistoriesListViewModel>
    {
        private readonly TransactionHistoriesQueryManager _queryManager;

        public GetTransactionHistoriesListQueryHandler(TransactionHistoriesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<TransactionHistoriesListViewModel> Handle(GetTransactionHistoriesListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

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
