using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Queries.GetProductModelProductDescriptionCultures
{
    public partial class GetProductModelProductDescriptionCulturesListQuery : IRequest<ProductModelProductDescriptionCulturesListViewModel>, IDataTableInfo<ProductModelProductDescriptionCultureSummary>
    {
        public DataTableInfo<ProductModelProductDescriptionCultureSummary> DataTable { get; set; }
    }
}
