using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Purchasing.Vendor.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Purchasing.Vendor.Queries.GetVendors;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.Vendor.Queries.GetVendorDetail
{
    public partial class GetVendorDetailQuery : IRequest<VendorLookupModel>
    {
        public int VendorID { get; set; }
    }
}
