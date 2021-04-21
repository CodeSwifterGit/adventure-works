using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderHeader.Commands.DeletePurchaseOrderHeader
{
    public partial class DeletePurchaseOrderHeaderSetCommand : IRequest
    {
        public List<DeletePurchaseOrderHeaderCommand> Commands { get; set; }
    }
}