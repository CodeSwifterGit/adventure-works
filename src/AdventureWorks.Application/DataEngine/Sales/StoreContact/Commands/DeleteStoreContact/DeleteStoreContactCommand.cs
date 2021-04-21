using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.StoreContact.Commands.DeleteStoreContact
{
    public partial class DeleteStoreContactCommand : IRequest
    {
        public int CustomerID { get; set; }
        public int ContactID { get; set; }
    }
}