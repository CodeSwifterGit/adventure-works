using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.Vendor.Commands.DeleteVendor
{
    public partial class DeleteVendorCommand : IRequest
    {
        public int VendorID { get; set; }
    }
}