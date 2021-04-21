using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.Customer.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Sales.Customer.Queries.GetCustomers
{
    public partial class GetCustomersListQuery : IRequest<CustomersListViewModel>, IDataTableInfo<CustomerSummary>
    {
        public DataTableInfo<CustomerSummary> DataTable { get; set; }
    }
}
