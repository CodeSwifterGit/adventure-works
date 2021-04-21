using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.Customer.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.Customer.Queries.GetCustomers
{
    public partial class GetCustomersBySalesTerritoryListQueryHandler : IRequestHandler<GetCustomersBySalesTerritoryListQuery, CustomersListViewModel>
    {
        private readonly CustomersQueryManager _queryManager;

        public GetCustomersBySalesTerritoryListQueryHandler(CustomersQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<CustomersListViewModel> Handle(GetCustomersBySalesTerritoryListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.TerritoryID == request.TerritoryID);

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
