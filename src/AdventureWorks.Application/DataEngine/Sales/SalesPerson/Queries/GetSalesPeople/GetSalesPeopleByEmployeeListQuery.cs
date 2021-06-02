using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesPerson.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesPerson.Queries.GetSalesPeople
{
    public partial class GetSalesPeopleByEmployeeListQuery : IRequest<SalesPeopleListViewModel>, IDataTableInfo<SalesPersonSummary>
    {
        public int SalesPersonID { get; set; }
        public DataTableInfo<SalesPersonSummary> DataTable { get; set; }
    }
}
