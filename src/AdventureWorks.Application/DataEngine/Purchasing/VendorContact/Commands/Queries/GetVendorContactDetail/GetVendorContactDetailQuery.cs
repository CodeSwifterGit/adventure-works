using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Queries.GetVendorContacts;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Queries.GetVendorContactDetail
{
    public partial class GetVendorContactDetailQuery : IRequest<VendorContactLookupModel>
    {
        public int VendorID { get; set; }
        public int ContactID { get; set; }
    }
}
