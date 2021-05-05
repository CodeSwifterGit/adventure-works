using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.CreditCard.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.CreditCard.Queries.GetCreditCards
{
    public partial class GetCreditCardsListQueryHandler : IRequestHandler<GetCreditCardsListQuery, CreditCardsListViewModel>
    {
        private readonly CreditCardsQueryManager _queryManager;

        public GetCreditCardsListQueryHandler(CreditCardsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<CreditCardsListViewModel> Handle(GetCreditCardsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new CreditCardsListViewModel
            {
                CreditCards = listResult,
                DataTable = DataTableResponseInfo<CreditCardSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
