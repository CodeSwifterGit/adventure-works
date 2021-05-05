using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Queries.GetProductCostHistories;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Queries.GetProductCostHistoryDetail
{
    public partial class GetProductCostHistoryDetailQuery : IRequest<ProductCostHistoryLookupModel>
    {
        public int ProductID { get; set; }
        public DateTime StartDate { get; set; }
    }
}
