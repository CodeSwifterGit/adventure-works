using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.ContactCreditCard.Queries.GetContactCreditCards
{
    public partial class GetContactCreditCardsByCreditCardListQuery : IRequest<ContactCreditCardsListViewModel>, IDataTableInfo<ContactCreditCardSummary>
    {
        public int CreditCardID { get; set; }
        public DataTableInfo<ContactCreditCardSummary> DataTable { get; set; }
    }
}