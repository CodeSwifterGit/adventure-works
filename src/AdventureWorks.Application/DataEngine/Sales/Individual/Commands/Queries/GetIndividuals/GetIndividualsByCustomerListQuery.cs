using MediatR;
using AdventureWorks.Application.DataEngine;
using AdventureWorks.Application.DataEngine.DataEngine;
using AdventureWorks.Application.DataEngine.Sales.Individual.Queries.QueryManager;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.BaseDomain.Enums;
using AdventureWorks.BaseDomain.Interfaces;
using AdventureWorks.BaseDomain.CustomTypes;

namespace AdventureWorks.Application.DataEngine.Sales.Individual.Queries.GetIndividuals
{
    public partial class GetIndividualsByCustomerListQuery : IRequest<IndividualsListViewModel>, IDataTableInfo<IndividualSummary>
    {
        public int CustomerID { get; set; }
        public DataTableInfo<IndividualSummary> DataTable { get; set; }
    }
}
