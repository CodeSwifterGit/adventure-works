using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.CreditCard.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Sales.CreditCard.Queries.GetCreditCards
{
    public partial class GetCreditCardsListQuery : IRequest<CreditCardsListViewModel>, IDataTableInfo<CreditCardSummary>
    {
        public DataTableInfo<CreditCardSummary> DataTable { get; set; }
    }
}
