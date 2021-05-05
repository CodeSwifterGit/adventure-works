using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Queries.GetProductVendors;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Queries.GetProductVendorDetail
{
    public partial class GetProductVendorDetailQuery : IRequest<ProductVendorLookupModel>
    {
        public int ProductID { get; set; }
        public int VendorID { get; set; }
    }
}
