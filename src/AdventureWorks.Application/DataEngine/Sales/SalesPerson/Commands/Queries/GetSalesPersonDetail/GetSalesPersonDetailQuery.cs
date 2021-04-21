using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Sales.SalesPerson.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Sales.SalesPerson.Queries.GetSalesPeople;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesPerson.Queries.GetSalesPersonDetail
{
    public partial class GetSalesPersonDetailQuery : IRequest<SalesPersonLookupModel>
    {
        public int SalesPersonID { get; set; }
    }
}
