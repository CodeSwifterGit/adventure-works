using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Queries.GetSpecialOfferProducts
{
    public partial class GetSpecialOfferProductsListQuery : IRequest<SpecialOfferProductsListViewModel>, IDataTableInfo<SpecialOfferProductSummary>
    {
        public DataTableInfo<SpecialOfferProductSummary> DataTable { get; set; }
    }
}
