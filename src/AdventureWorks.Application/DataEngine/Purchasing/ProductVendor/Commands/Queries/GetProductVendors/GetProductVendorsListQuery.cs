using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Purchasing.ProductVendor.Queries.GetProductVendors
{
    public partial class GetProductVendorsListQuery : IRequest<ProductVendorsListViewModel>, IDataTableInfo<ProductVendorSummary>
    {
        public DataTableInfo<ProductVendorSummary> DataTable { get; set; }
    }
}
