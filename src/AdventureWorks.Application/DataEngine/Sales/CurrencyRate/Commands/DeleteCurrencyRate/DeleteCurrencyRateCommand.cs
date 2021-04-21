using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Commands.DeleteCurrencyRate
{
    public partial class DeleteCurrencyRateCommand : IRequest
    {
        public int CurrencyRateID { get; set; }
    }
}