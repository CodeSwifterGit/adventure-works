using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Queries.GetProductListPriceHistories;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Queries.GetProductListPriceHistoryDetail
{
    public partial class GetProductListPriceHistoryDetailQuery : IRequest<ProductListPriceHistoryLookupModel>
    {
        public int ProductID { get; set; }
        public DateTime StartDate { get; set; }
    }
}
