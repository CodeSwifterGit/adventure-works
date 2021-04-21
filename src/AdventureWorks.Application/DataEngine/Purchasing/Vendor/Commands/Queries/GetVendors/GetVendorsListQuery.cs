using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Purchasing.Vendor.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.Purchasing.Vendor.Queries.GetVendors
{
    public partial class GetVendorsListQuery : IRequest<VendorsListViewModel>, IDataTableInfo<VendorSummary>
    {
        public DataTableInfo<VendorSummary> DataTable { get; set; }
    }
}
