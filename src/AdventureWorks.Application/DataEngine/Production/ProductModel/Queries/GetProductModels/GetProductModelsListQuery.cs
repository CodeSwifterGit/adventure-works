using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductModel.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Production.ProductModel.Queries.GetProductModels
{
    public partial class GetProductModelsListQuery : IRequest<ProductModelsListViewModel>, IDataTableInfo<ProductModelSummary>
    {
        public DataTableInfo<ProductModelSummary> DataTable { get; set; }
    }
}
