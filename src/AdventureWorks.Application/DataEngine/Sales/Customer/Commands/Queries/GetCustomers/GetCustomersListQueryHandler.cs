using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.Customer.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.Customer.Queries.GetCustomers
{
    public partial class GetCustomersListQueryHandler : IRequestHandler<GetCustomersListQuery, CustomersListViewModel>
    {
        private readonly CustomersQueryManager _queryManager;

        public GetCustomersListQueryHandler(CustomersQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<CustomersListViewModel> Handle(GetCustomersListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new CustomersListViewModel
            {
                Customers = listResult,
                DataTable = DataTableResponseInfo<CustomerSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
