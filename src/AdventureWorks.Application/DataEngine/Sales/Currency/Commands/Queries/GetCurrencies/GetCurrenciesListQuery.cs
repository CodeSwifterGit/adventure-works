using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.Currency.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Sales.Currency.Queries.GetCurrencies
{
    public partial class GetCurrenciesListQuery : IRequest<CurrenciesListViewModel>, IDataTableInfo<CurrencySummary>
    {
        public DataTableInfo<CurrencySummary> DataTable { get; set; }
    }
}
