using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Sales.StoreContact.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Sales.StoreContact.Queries.GetStoreContacts;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.StoreContact.Queries.GetStoreContactDetail
{
    public partial class GetStoreContactDetailQuery : IRequest<StoreContactLookupModel>
    {
        public int CustomerID { get; set; }
        public int ContactID { get; set; }
    }
}
