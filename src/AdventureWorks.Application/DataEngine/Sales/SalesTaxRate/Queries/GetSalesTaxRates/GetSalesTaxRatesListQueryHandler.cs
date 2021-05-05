using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Queries.GetSalesTaxRates
{
    public partial class GetSalesTaxRatesListQueryHandler : IRequestHandler<GetSalesTaxRatesListQuery, SalesTaxRatesListViewModel>
    {
        private readonly SalesTaxRatesQueryManager _queryManager;

        public GetSalesTaxRatesListQueryHandler(SalesTaxRatesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<SalesTaxRatesListViewModel> Handle(GetSalesTaxRatesListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new SalesTaxRatesListViewModel
            {
                SalesTaxRates = listResult,
                DataTable = DataTableResponseInfo<SalesTaxRateSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
