using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Queries.GetSalesTerritoryHistories
{
    public partial class GetSalesTerritoryHistoriesBySalesPersonListQuery : IRequest<SalesTerritoryHistoriesListViewModel>, IDataTableInfo<SalesTerritoryHistorySummary>
    {
        public int SalesPersonID { get; set; }
        public DataTableInfo<SalesTerritoryHistorySummary> DataTable { get; set; }
    }
}
