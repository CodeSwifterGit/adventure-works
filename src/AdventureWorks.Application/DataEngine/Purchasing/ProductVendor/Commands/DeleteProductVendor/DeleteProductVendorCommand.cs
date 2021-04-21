using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Commands.DeleteProductVendor
{
    public partial class DeleteProductVendorCommand : IRequest
    {
        public int ProductID { get; set; }
        public int VendorID { get; set; }
    }
}