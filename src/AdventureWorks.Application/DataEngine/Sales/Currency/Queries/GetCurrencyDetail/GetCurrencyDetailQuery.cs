using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Sales.Currency.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Sales.Currency.Queries.GetCurrencies;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.Currency.Queries.GetCurrencyDetail
{
    public partial class GetCurrencyDetailQuery : IRequest<CurrencyLookupModel>
    {
        public string CurrencyCode { get; set; }
    }
}
