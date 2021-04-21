using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.Currency.Commands.DeleteCurrency
{
    public partial class DeleteCurrencyCommand : IRequest
    {
        public string CurrencyCode { get; set; }
    }
}