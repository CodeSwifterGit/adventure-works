using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Queries.GetProductModelIllustrations
{
    public partial class GetProductModelIllustrationsByProductModelListQuery : IRequest<ProductModelIllustrationsListViewModel>, IDataTableInfo<ProductModelIllustrationSummary>
    {
        public int ProductModelID { get; set; }
        public DataTableInfo<ProductModelIllustrationSummary> DataTable { get; set; }
    }
}
