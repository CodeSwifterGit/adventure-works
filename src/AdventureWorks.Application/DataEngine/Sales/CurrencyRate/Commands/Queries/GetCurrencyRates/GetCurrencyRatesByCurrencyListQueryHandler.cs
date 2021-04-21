using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Queries.GetCurrencyRates
{
    public partial class GetCurrencyRatesByCurrencyListQueryHandler : IRequestHandler<GetCurrencyRatesByCurrencyListQuery, CurrencyRatesListViewModel>
    {
        private readonly CurrencyRatesQueryManager _queryManager;

        public GetCurrencyRatesByCurrencyListQueryHandler(CurrencyRatesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<CurrencyRatesListViewModel> Handle(GetCurrencyRatesByCurrencyListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.FromCurrencyCode == request.FromCurrencyCode && x.ToCurrencyCode == request.ToCurrencyCode);

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
