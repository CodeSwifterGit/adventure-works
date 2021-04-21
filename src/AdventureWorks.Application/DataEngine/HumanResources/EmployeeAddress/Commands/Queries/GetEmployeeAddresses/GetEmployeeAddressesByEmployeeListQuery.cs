using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Queries.GetEmployeeAddresses
{
    public partial class GetEmployeeAddressesByEmployeeListQuery : IRequest<EmployeeAddressesListViewModel>, IDataTableInfo<EmployeeAddressSummary>
    {
        public int EmployeeID { get; set; }
        public DataTableInfo<EmployeeAddressSummary> DataTable { get; set; }
    }
}
