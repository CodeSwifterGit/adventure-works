using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Queries.GetSalesTaxRates
{
    public partial class GetSalesTaxRatesListQuery : IRequest<SalesTaxRatesListViewModel>, IDataTableInfo<SalesTaxRateSummary>
    {
        public DataTableInfo<SalesTaxRateSummary> DataTable { get; set; }
    }
}
