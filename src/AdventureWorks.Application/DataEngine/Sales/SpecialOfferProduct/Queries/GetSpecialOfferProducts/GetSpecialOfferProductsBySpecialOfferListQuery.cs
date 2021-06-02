using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.SpecialOfferProduct.Queries.GetSpecialOfferProducts
{
    public partial class GetSpecialOfferProductsBySpecialOfferListQuery : IRequest<SpecialOfferProductsListViewModel>, IDataTableInfo<SpecialOfferProductSummary>
    {
        public int SpecialOfferID { get; set; }
        public DataTableInfo<SpecialOfferProductSummary> DataTable { get; set; }
    }
}
