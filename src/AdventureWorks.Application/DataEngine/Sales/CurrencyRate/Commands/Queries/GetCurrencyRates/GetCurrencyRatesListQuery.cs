using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Sales.CurrencyRate.Queries.GetCurrencyRates
{
    public partial class GetCurrencyRatesListQuery : IRequest<CurrencyRatesListViewModel>, IDataTableInfo<CurrencyRateSummary>
    {
        public DataTableInfo<CurrencyRateSummary> DataTable { get; set; }
    }
}
