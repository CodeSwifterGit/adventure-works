using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Queries.GetCurrencyRates
{
    public partial class GetCurrencyRatesByCurrencyListQuery : IRequest<CurrencyRatesListViewModel>, IDataTableInfo<CurrencyRateSummary>
    {
        public string FromCurrencyCode { get; set; }
        public string ToCurrencyCode { get; set; }
        public DataTableInfo<CurrencyRateSummary> DataTable { get; set; }
    }
}
