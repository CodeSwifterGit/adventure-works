using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.TransactionHistoryArchive.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Application.DataEngine.Production.TransactionHistoryArchive.Queries.GetTransactionHistoryArchives
{
    public partial class GetTransactionHistoryArchivesListQueryHandler : IRequestHandler<GetTransactionHistoryArchivesListQuery, TransactionHistoryArchivesListViewModel>
    {
        private readonly TransactionHistoryArchivesQueryManager _queryManager;

        public GetTransactionHistoryArchivesListQueryHandler(TransactionHistoryArchivesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<TransactionHistoryArchivesListViewModel> Handle(GetTransactionHistoryArchivesListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new TransactionHistoryArchivesListViewModel
            {
                TransactionHistoryArchives = listResult,
                DataTable = DataTableResponseInfo<TransactionHistoryArchiveSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
