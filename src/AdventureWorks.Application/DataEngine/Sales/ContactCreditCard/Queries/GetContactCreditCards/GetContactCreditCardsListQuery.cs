using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Queries.GetContactCreditCards
{
    public partial class GetContactCreditCardsListQuery : IRequest<ContactCreditCardsListViewModel>, IDataTableInfo<ContactCreditCardSummary>
    {
        public DataTableInfo<ContactCreditCardSummary> DataTable { get; set; }
    }
}
