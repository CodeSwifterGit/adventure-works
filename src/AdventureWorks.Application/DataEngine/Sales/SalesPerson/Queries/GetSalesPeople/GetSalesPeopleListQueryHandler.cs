using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesPerson.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.SalesPerson.Queries.GetSalesPeople
{
    public partial class GetSalesPeopleListQueryHandler : IRequestHandler<GetSalesPeopleListQuery, SalesPeopleListViewModel>
    {
        private readonly SalesPeopleQueryManager _queryManager;

        public GetSalesPeopleListQueryHandler(SalesPeopleQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<SalesPeopleListViewModel> Handle(GetSalesPeopleListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

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
