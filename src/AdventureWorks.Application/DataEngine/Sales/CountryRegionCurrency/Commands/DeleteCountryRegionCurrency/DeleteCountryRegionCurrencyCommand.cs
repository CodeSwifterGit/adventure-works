using System;
using MediatR;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Commands.DeleteCountryRegionCurrency
{
    public partial class DeleteCountryRegionCurrencyCommand : IRequest
    {
        public string CountryRegionCode { get; set; }
        public string CurrencyCode { get; set; }
    }
}