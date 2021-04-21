using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorks.Application.DataEngine;
using System.Linq;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Queries.QueryManager;
using Entities = AdventureWorks.Domain.Entities.Sales;
using AdventureWorks.Domain;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Queries.GetContactCreditCards
{
    public partial class GetContactCreditCardsByContactListQueryHandler : IRequestHandler<GetContactCreditCardsByContactListQuery, ContactCreditCardsListViewModel>
    {
        private readonly ContactCreditCardsQueryManager _queryManager;

        public GetContactCreditCardsByContactListQueryHandler(ContactCreditCardsQueryManager queryManager)
        {
            _queryManager = queryManager;
        }

        public async Task<ContactCreditCardsListViewModel> Handle(GetContactCreditCardsByContactListQuery request, CancellationToken cancellationToken)
        {
            var query = _queryManager.GetQuery()
            .Where(x => x.ContactID == request.ContactID);

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
