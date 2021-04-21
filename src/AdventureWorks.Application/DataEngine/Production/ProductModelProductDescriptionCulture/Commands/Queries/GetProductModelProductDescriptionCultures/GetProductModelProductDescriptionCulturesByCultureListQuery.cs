using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.ProductModelProductDescriptionCulture.Queries.GetProductModelProductDescriptionCultures
{
    public partial class GetProductModelProductDescriptionCulturesByCultureListQuery : IRequest<ProductModelProductDescriptionCulturesListViewModel>, IDataTableInfo<ProductModelProductDescriptionCultureSummary>
    {
        public string CultureID { get; set; }
        public DataTableInfo<ProductModelProductDescriptionCultureSummary> DataTable { get; set; }
    }
}
