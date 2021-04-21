using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Queries.GetCountryRegionCurrencies;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.CountryRegionCurrency.Queries.GetCountryRegionCurrencyDetail
{
    public partial class GetCountryRegionCurrencyDetailQuery : IRequest<CountryRegionCurrencyLookupModel>
    {
        public string CountryRegionCode { get; set; }
        public string CurrencyCode { get; set; }
    }
}
