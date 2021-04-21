using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.CustomerAddress.Commands.DeleteCustomerAddress
{
    public partial class DeleteCustomerAddressCommand : IRequest
    {
        public int CustomerID { get; set; }
        public int AddressID { get; set; }
    }
}