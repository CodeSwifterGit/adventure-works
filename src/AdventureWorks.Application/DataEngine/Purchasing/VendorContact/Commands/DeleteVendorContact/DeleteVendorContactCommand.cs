using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.VendorContact.Commands.DeleteVendorContact
{
    public partial class DeleteVendorContactCommand : IRequest
    {
        public int VendorID { get; set; }
        public int ContactID { get; set; }
    }
}