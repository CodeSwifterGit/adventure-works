using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Production.ProductCostHistory.Commands.DeleteProductCostHistory
{
    public partial class DeleteProductCostHistorySetCommand : IRequest
    {
        public List<DeleteProductCostHistoryCommand> Commands { get; set; }
    }
}