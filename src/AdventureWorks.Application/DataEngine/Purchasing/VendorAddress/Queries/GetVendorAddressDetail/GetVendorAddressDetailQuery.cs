using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Queries.GetVendorAddresses;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Queries.GetVendorAddressDetail
{
    public partial class GetVendorAddressDetailQuery : IRequest<VendorAddressLookupModel>
    {
        public int VendorID { get; set; }
        public int AddressID { get; set; }
    }
}
