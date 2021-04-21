using System;
using MediatR;
using AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Queries.QueryManager;
using AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Queries.GetCurrencyRates;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Queries.GetCurrencyRateDetail
{
    public partial class GetCurrencyRateDetailQuery : IRequest<CurrencyRateLookupModel>
    {
        public int CurrencyRateID { get; set; }
    }
}
