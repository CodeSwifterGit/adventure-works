using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Sales.SalesTaxRate.Commands.DeleteSalesTaxRate
{
    public partial class DeleteSalesTaxRateSetCommand : IRequest
    {
        public List<DeleteSalesTaxRateCommand> Commands { get; set; }
    }
}