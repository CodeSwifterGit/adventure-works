using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Sales.Currency.Commands.DeleteCurrency
{
    public partial class DeleteCurrencySetCommand : IRequest
    {
        public List<DeleteCurrencyCommand> Commands { get; set; }
    }
}