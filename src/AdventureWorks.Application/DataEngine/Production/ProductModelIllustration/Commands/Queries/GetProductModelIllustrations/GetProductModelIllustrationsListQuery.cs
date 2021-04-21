using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Production.ProductModelIllustration.Queries.GetProductModelIllustrations
{
    public partial class GetProductModelIllustrationsListQuery : IRequest<ProductModelIllustrationsListViewModel>, IDataTableInfo<ProductModelIllustrationSummary>
    {
        public DataTableInfo<ProductModelIllustrationSummary> DataTable { get; set; }
    }
}
