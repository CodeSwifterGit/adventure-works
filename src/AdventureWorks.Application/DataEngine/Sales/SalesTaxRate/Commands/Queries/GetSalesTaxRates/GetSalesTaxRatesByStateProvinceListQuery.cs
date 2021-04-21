using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Queries.GetSalesTaxRates
{
    public partial class GetSalesTaxRatesByStateProvinceListQuery : IRequest<SalesTaxRatesListViewModel>, IDataTableInfo<SalesTaxRateSummary>
    {
        public int StateProvinceID { get; set; }
        public DataTableInfo<SalesTaxRateSummary> DataTable { get; set; }
    }
}
