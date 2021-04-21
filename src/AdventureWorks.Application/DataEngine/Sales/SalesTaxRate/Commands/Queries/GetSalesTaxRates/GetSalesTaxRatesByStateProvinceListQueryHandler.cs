using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Queries.GetSalesTaxRates
{
    public partial class GetSalesTaxRatesByStateProvinceListQueryHandler : IRequestHandler<GetSalesTaxRatesByStateProvinceListQuery, SalesTaxRatesListViewModel>
    {
        private readonly SalesTaxRatesQueryManager _queryManager;

        public GetSalesTaxRatesByStateProvinceListQueryHandler(SalesTaxRatesQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<SalesTaxRatesListViewModel> Handle(GetSalesTaxRatesByStateProvinceListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.StateProvinceID == request.StateProvinceID);

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
