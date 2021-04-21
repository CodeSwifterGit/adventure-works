using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Queries.GetSpecialOffers
{
    public partial class GetSpecialOffersListQueryHandler : IRequestHandler<GetSpecialOffersListQuery, SpecialOffersListViewModel>
    {
        private readonly SpecialOffersQueryManager _queryManager;

        public GetSpecialOffersListQueryHandler(SpecialOffersQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<SpecialOffersListViewModel> Handle(GetSpecialOffersListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new SpecialOffersListViewModel
            {
                SpecialOffers = listResult,
                DataTable = DataTableResponseInfo<SpecialOfferSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
