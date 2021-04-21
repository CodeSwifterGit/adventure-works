using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductInventory.Commands.DeleteProductInventory
{
    public partial class DeleteProductInventoryCommand : IRequest
    {
        public int ProductID { get; set; }
        public short LocationID { get; set; }
    }
}