using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Queries.GetSalesTerritories;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTerritory.Queries.GetSalesTerritoryDetail
{
    public partial class GetSalesTerritoryDetailQuery : IRequest<SalesTerritoryLookupModel>
    {
        public int TerritoryID { get; set; }
    }
}
