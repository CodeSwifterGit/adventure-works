using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.VendorAddress.Commands.DeleteVendorAddress
{
    public partial class DeleteVendorAddressCommand : IRequest
    {
        public int VendorID { get; set; }
        public int AddressID { get; set; }
    }
}