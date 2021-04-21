using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Commands.DeleteCurrencyRate
{
    public partial class DeleteCurrencyRateSetCommand : IRequest
    {
        public List<DeleteCurrencyRateCommand> Commands { get; set; }
    }
}