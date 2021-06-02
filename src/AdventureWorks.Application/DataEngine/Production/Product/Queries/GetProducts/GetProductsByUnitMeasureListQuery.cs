using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Production.Product.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Production.Product.Queries.GetProducts
{
    public partial class GetProductsByUnitMeasureListQuery : IRequest<ProductsListViewModel>, IDataTableInfo<ProductSummary>
    {
        public string SizeUnitMeasureCode { get; set; }
        public string WeightUnitMeasureCode { get; set; }
        public DataTableInfo<ProductSummary> DataTable { get; set; }
    }
}
