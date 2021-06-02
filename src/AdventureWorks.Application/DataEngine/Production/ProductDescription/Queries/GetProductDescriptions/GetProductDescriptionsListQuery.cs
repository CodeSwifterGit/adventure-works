using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductDescription.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Production.ProductDescription.Queries.GetProductDescriptions
{
    public partial class GetProductDescriptionsListQuery : IRequest<ProductDescriptionsListViewModel>, IDataTableInfo<ProductDescriptionSummary>
    {
        public DataTableInfo<ProductDescriptionSummary> DataTable { get; set; }
    }
}
