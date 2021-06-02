using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Queries.GetProductVendors
{
    public partial class GetProductVendorsByUnitMeasureListQuery : IRequest<ProductVendorsListViewModel>, IDataTableInfo<ProductVendorSummary>
    {
        public string UnitMeasureCode { get; set; }
        public DataTableInfo<ProductVendorSummary> DataTable { get; set; }
    }
}
