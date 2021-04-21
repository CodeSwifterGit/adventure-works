using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Queries.GetSalesTerritoryHistories;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritoryHistory.Queries.GetSalesTerritoryHistoryDetail
{
    public partial class GetSalesTerritoryHistoryDetailQuery : IRequest<SalesTerritoryHistoryLookupModel>
    {
        public int SalesPersonID { get; set; }
        public int TerritoryID { get; set; }
        public DateTime StartDate { get; set; }
    }
}
