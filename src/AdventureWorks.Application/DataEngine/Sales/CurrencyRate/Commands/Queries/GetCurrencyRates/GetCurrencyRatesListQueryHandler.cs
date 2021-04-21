using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Queries.GetCurrencyRates
{
    public partial class GetCurrencyRatesListQueryHandler : IRequestHandler<GetCurrencyRatesListQuery, CurrencyRatesListViewModel>
    {
        private readonly CurrencyRatesQueryManager _queryManager;

        public GetCurrencyRatesListQueryHandler(CurrencyRatesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<CurrencyRatesListViewModel> Handle(GetCurrencyRatesListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new CurrencyRatesListViewModel
            {
                CurrencyRates = listResult,
                DataTable = DataTableResponseInfo<CurrencyRateSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
