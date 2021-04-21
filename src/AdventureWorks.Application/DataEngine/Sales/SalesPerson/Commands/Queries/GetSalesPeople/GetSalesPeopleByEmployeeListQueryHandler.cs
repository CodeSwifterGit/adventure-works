using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesPerson.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesPerson.Queries.GetSalesPeople
{
    public partial class GetSalesPeopleByEmployeeListQueryHandler : IRequestHandler<GetSalesPeopleByEmployeeListQuery, SalesPeopleListViewModel>
    {
        private readonly SalesPeopleQueryManager _queryManager;

        public GetSalesPeopleByEmployeeListQueryHandler(SalesPeopleQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<SalesPeopleListViewModel> Handle(GetSalesPeopleByEmployeeListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.SalesPersonID == request.SalesPersonID);

            var listResult =
                      await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new SalesPeopleListViewModel
            {
                SalesPeople = listResult,
                DataTable = DataTableResponseInfo<SalesPersonSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
