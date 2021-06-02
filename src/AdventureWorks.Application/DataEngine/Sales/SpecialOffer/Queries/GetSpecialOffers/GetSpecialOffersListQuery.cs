using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Sales.SpecialOffer.Queries.GetSpecialOffers
{
    public partial class GetSpecialOffersListQuery : IRequest<SpecialOffersListViewModel>, IDataTableInfo<SpecialOfferSummary>
    {
        public DataTableInfo<SpecialOfferSummary> DataTable { get; set; }
    }
}
