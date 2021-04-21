using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Sales.Store.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Sales.Store.Queries.GetStores;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.Store.Queries.GetStoreDetail
{
    public partial class GetStoreDetailQuery : IRequest<StoreLookupModel>
    {
        public int CustomerID { get; set; }
    }
}
