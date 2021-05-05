using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Production.ProductInventory.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Production.ProductInventory.Queries.GetProductInventories;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductInventory.Queries.GetProductInventoryDetail
{
    public partial class GetProductInventoryDetailQuery : IRequest<ProductInventoryLookupModel>
    {
        public int ProductID { get; set; }
        public short LocationID { get; set; }
    }
}
