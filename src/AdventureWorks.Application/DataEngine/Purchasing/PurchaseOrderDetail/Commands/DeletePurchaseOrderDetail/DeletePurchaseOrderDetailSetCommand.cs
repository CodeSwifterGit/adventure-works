using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Purchasing.PurchaseOrderDetail.Commands.DeletePurchaseOrderDetail
{
    public partial class DeletePurchaseOrderDetailSetCommand : IRequest
    {
        public List<DeletePurchaseOrderDetailCommand> Commands { get; set; }
    }
}