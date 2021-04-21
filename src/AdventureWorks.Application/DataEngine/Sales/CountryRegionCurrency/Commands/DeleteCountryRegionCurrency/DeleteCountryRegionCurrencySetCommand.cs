using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Commands.DeleteCountryRegionCurrency
{
    public partial class DeleteCountryRegionCurrencySetCommand : IRequest
    {
        public List<DeleteCountryRegionCurrencyCommand> Commands { get; set; }
    }
}