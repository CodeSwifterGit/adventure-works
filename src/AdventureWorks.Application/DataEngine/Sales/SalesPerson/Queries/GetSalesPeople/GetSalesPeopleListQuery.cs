using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesPerson.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Sales.SalesPerson.Queries.GetSalesPeople
{
    public partial class GetSalesPeopleListQuery : IRequest<SalesPeopleListViewModel>, IDataTableInfo<SalesPersonSummary>
    {
        public DataTableInfo<SalesPersonSummary> DataTable { get; set; }
    }
}
