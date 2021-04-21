using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;

namespace AdventureWorks.Application.DataEngine.HumanResources.EmployeeAddress.Queries.GetEmployeeAddresses
{
    public partial class GetEmployeeAddressesListQuery : IRequest<EmployeeAddressesListViewModel>, IDataTableInfo<EmployeeAddressSummary>
    {
        public DataTableInfo<EmployeeAddressSummary> DataTable { get; set; }
    }
}
