using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SalesOrderDetail.Queries.GetSalesOrderDetails
{
    public partial class GetSalesOrderDetailsBySpecialOfferProductListQueryHandler : IRequestHandler<GetSalesOrderDetailsBySpecialOfferProductListQuery, SalesOrderDetailsListViewModel>
    {
        private readonly SalesOrderDetailsQueryManager _queryManager;

        public GetSalesOrderDetailsBySpecialOfferProductListQueryHandler(SalesOrderDetailsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<SalesOrderDetailsListViewModel> Handle(GetSalesOrderDetailsBySpecialOfferProductListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.ProductID == request.ProductID && x.SpecialOfferID == request.SpecialOfferID);

            var listResult =
                      await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new SalesOrderDetailsListViewModel
            {
                SalesOrderDetails = listResult,
                DataTable = DataTableResponseInfo<SalesOrderDetailSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
