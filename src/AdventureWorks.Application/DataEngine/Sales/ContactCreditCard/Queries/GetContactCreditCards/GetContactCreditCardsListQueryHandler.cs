using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Queries.GetContactCreditCards
{
    public partial class GetContactCreditCardsListQueryHandler : IRequestHandler<GetContactCreditCardsListQuery, ContactCreditCardsListViewModel>
    {
        private readonly ContactCreditCardsQueryManager _queryManager;

        public GetContactCreditCardsListQueryHandler(ContactCreditCardsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ContactCreditCardsListViewModel> Handle(GetContactCreditCardsListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery();

            var listResult =
                    await _queryManager.RequestData(query, request.DataTable, cancellationToken);

            return new ContactCreditCardsListViewModel
            {
                ContactCreditCards = listResult,
                DataTable = DataTableResponseInfo<ContactCreditCardSummary>.FromDataTableInfo(request.DataTable)
            };
        }
    }
}
