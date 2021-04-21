using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Queries.GetSpecialOfferProducts
{
    public partial class GetSpecialOfferProductsBySpecialOfferListQueryHandler : IRequestHandler<GetSpecialOfferProductsBySpecialOfferListQuery, SpecialOfferProductsListViewModel>
    {
        private readonly SpecialOfferProductsQueryManager _queryManager;

        public GetSpecialOfferProductsBySpecialOfferListQueryHandler(SpecialOfferProductsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<SpecialOfferProductsListViewModel> Handle(GetSpecialOfferProductsBySpecialOfferListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.SpecialOfferID == request.SpecialOfferID);

            var listResult =
                      await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new SpecialOfferProductsListViewModel
            {
                SpecialOfferProducts = listResult,
                DataTable = DataTableResponseInfo<SpecialOfferProductSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
