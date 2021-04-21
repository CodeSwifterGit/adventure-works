using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Queries.GetSpecialOfferProducts
{
    public partial class GetSpecialOfferProductsListQueryHandler : IRequestHandler<GetSpecialOfferProductsListQuery, SpecialOfferProductsListViewModel>
    {
        private readonly SpecialOfferProductsQueryManager _queryManager;

        public GetSpecialOfferProductsListQueryHandler(SpecialOfferProductsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<SpecialOfferProductsListViewModel> Handle(GetSpecialOfferProductsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

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
