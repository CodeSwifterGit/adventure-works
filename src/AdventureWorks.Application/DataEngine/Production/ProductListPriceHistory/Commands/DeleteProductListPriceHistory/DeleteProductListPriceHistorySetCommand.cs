using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Production.ProductListPriceHistory.Commands.DeleteProductListPriceHistory
{
    public partial class DeleteProductListPriceHistorySetCommand : IRequest
    {
        public List<DeleteProductListPriceHistoryCommand> Commands { get; set; }
    }
}